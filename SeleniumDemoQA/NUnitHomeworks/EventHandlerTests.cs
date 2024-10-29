namespace NUnitHomeworks
{
    internal class EventHandlerTests
    {
        public class Button
        {
            // Define the event using EventHandler
            public event EventHandler Clicked;

            // Method to simulate a button click, which raises the Clicked event
            public void OnClick()
            {
                // Raise the event if there are any subscribers
                Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

        [TestFixture]
        public class ButtonTests
        {
            // Test 1: Check if event handler responds when subscribed
            [Test]
            public void Button_WhenClicked_ShouldTriggerEventHandler()
            {
                // Arrange
                var button = new Button();
                bool eventTriggered = false;

                // Act: subscribe to the Clicked event and set the flag when event is triggered
                button.Clicked += (sender, args) => eventTriggered = true;

                button.OnClick();

                // Assert
                Assert.IsTrue(eventTriggered, "Event handler should trigger when the button is clicked.");
            }

            // Test 2: Check that multiple event handlers can subscribe to the same event
            [Test]
            public void Button_WhenClicked_ShouldTriggerMultipleEventHandlers()
            {
                // Arrange
                var button = new Button();
                int eventTriggerCount = 0;

                // Act: subscribe multiple handlers to the Clicked event
                button.Clicked += (sender, args) => eventTriggerCount++;
                button.Clicked += (sender, args) => eventTriggerCount++;

                button.OnClick();

                // Assert
                Assert.AreEqual(2, eventTriggerCount, "All event handlers should trigger when the button is clicked.");
            }

            // Test 3: Ensure the event does not trigger when no subscribers are present
            [Test]
            public void Button_WhenNoSubscribers_EventDoesNotThrowException()
            {
                // Arrange
                var button = new Button();

                // Act & Assert: Call OnClick without any subscribers
                Assert.DoesNotThrow(() => button.OnClick(), "Event should not throw an exception when there are no subscribers.");
            }

            // Test 4: Verify event arguments are passed correctly
            [Test]
            public void Button_ClickedEvent_ShouldPassCorrectArguments()
            {
                // Arrange
                var button = new Button();
                object senderFromEvent = null;
                EventArgs argsFromEvent = null;

                // Act: subscribe and capture sender and arguments
                button.Clicked += (sender, args) =>
                {
                    senderFromEvent = sender;
                    argsFromEvent = args;
                };

                button.OnClick();

                // Assert
                Assert.AreEqual(button, senderFromEvent, "Sender should be the button itself.");
                Assert.AreEqual(EventArgs.Empty, argsFromEvent, "EventArgs should be EventArgs.Empty.");
            }
        }


        public class TextChangedEventArgs : EventArgs
        {
            public string OldText { get; }
            public string NewText { get; }

            public TextChangedEventArgs(string oldText, string newText)
            {
                OldText = oldText;
                NewText = newText;
            }
        }

        // TextBox class with a TextChanged event
        public class TextBox
        {
            private string _text;

            public string Text
            {
                get => _text;
                set
                {
                    if (_text != value)
                    {
                        var oldText = _text;
                        _text = value;
                        OnTextChanged(oldText, _text);
                    }
                }
            }

            // Define the event using EventHandler<TEventArgs> with custom EventArgs
            public event EventHandler<TextChangedEventArgs> TextChanged;

            // Method to raise the TextChanged event with the custom EventArgs
            protected virtual void OnTextChanged(string oldText, string newText)
            {
                TextChanged?.Invoke(this, new TextChangedEventArgs(oldText, newText));
            }
        }

        // Test 1: Verify TextChanged event triggers with correct old and new text
        [Test]
        public void TextBox_WhenTextChanges_ShouldTriggerTextChangedEventWithCorrectArgs()
        {
            // Arrange
            var textBox = new TextBox();
            string oldTextReceived = null;
            string newTextReceived = null;

            // Subscribe to the TextChanged event
            textBox.TextChanged += (sender, args) =>
            {
                oldTextReceived = args.OldText;
                newTextReceived = args.NewText;
            };

            // Act
            textBox.Text = "Hello";
            textBox.Text = "World";

            // Assert
            Assert.AreEqual("Hello", oldTextReceived, "Old text should be 'Hello'.");
            Assert.AreEqual("World", newTextReceived, "New text should be 'World'.");
        }

        // Test 2: Verify TextChanged event does not trigger if text remains the same
        [Test]
        public void TextBox_WhenTextIsUnchanged_ShouldNotTriggerTextChangedEvent()
        {
            // Arrange
            var textBox = new TextBox();
            bool eventTriggered = false;

            // Subscribe to the TextChanged event
            textBox.TextChanged += (sender, args) => eventTriggered = true;

            // Act
            textBox.Text = "Hello";
            textBox.Text = "Hello"; // Setting the same text

            // Assert
            Assert.IsFalse(eventTriggered, "TextChanged event should not trigger if the text remains unchanged.");
        }

        // Test 3: Verify that multiple subscribers receive the event
        [Test]
        public void TextBox_WhenTextChanges_ShouldNotifyAllSubscribers()
        {
            // Arrange
            var textBox = new TextBox();
            int eventTriggerCount = 0;

            // Subscribe multiple handlers to the TextChanged event
            textBox.TextChanged += (sender, args) => eventTriggerCount++;
            textBox.TextChanged += (sender, args) => eventTriggerCount++;

            // Act
            textBox.Text = "New Text";

            // Assert
            Assert.AreEqual(2, eventTriggerCount, "All subscribers should be notified when text changes.");
        }
    }
}
