﻿using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace PlaywrightAccesibility
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task FromPlaywrightDoc()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Assertions.Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync(@"
              - banner:
                - heading /Playwright enables reliable/ [level=1]
                - link ""Get started""
                - link ""Star microsoft/playwright on GitHub""
              - main:
                - img ""Browsers (Chromium, Firefox, WebKit)""
                - heading ""Any browser • Any platform • One API""
            ");
        }

        [Test]
        public async Task FromPlaywrightDocFull()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Assertions.Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync(@"
            - region ""Skip to main content"":
              - link ""Skip to main content""
            
            - banner:
              - heading ""Playwright enables reliable end-to-end testing for modern web apps."" [level=1]
              - link ""Get started""
              - link ""Star microsoft/playwright on GitHub"": Star
              - link ""67k+ stargazers on GitHub"": 67k+
            
            - contentinfo:
              - text: Learn
              - list:
                - listitem:
                  - link ""Getting started""


                - listitem:
                  - link ""Feature Videos""
              - text: Community
              
            ");
        }

        [Test]
        public async Task NV_partial()
        {
            await Page.GotoAsync("https://nv.ua/");

            await Assertions.Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync(@"
- banner:
  - link ""poster"":
    - img ""poster""
    - listitem:
      - link ""Радіо""
    - listitem:
      - link ""NV Преміум""
  - link ""пошук"": 
  - link ""Укр""
  - text: 
  - img
  - link ""Передплатити""

- text: Новини
- list:
  - listitem:
    - link ""Останнє""
  - listitem:
    - link ""Головне""
  - listitem:
    - link ""Популярне""

- contentinfo:
  - list:
    - listitem:
      - link ""Карта сайту""

    - listitem:
      - link ""Всі експерти NV Бізнес""
    - listitem:
      - link ""Автори та редактори сайту""
  - list:
    - listitem:
      - link ""Редакційна політика""
    - listitem:
      - link ""Про нас""

    - listitem:
      - link ""Договір користування""
    - listitem:
      - link ""Вакансії""
  - link ""наш twitter"": 
  - link ""наш instagram"": 
  - text: Додаток NV
  - paragraph: Developed by Apiko

  - list:
    - listitem:
      - link ""Бізнес""
      - link """"
    - listitem:
      - link ""Погляди""
      - link """"
    - listitem:
      - link ""Відео""
 
  - text: Слухайте нас
  - link ""poster"":
    - img ""poster""
  
  - paragraph: ""Політична реклама:""
  - text: Позиція
  - paragraph: ""Матеріали, відмічені значками, публікуються на правах реклами:""
  
- button ""Погоджуюсь""
- button """"
- link
            ");
        }
        
        [Test]
        public async Task NV()
        {
            await Page.GotoAsync("https://nv.ua/");

            await Assertions.Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync(@"
- banner:
  - link ""poster"":
    - img ""poster""
  - list:
    - listitem:
      - link ""Війна""
    - listitem:
      - link ""Новини""
    - listitem:
      - link ""Погляди""
    - listitem:
      - link ""Бізнес""
    - listitem:
      - link ""Life""
    - listitem:
      - link ""Радіо""
    - listitem:
      - link ""NV Преміум""
  - link ""пошук"": 
  - link ""Укр""
  - text: 
  - img
  - link ""Передплатити""
- link ""Найджел Гулд-Девіс Найджел Гулд-Девіс Три дуже небезпечні наслідки. Що робить Росія"":
  - img ""Найджел Гулд-Девіс""
  - text: Найджел Гулд-Девіс Три дуже небезпечні наслідки. Що робить Росія
- link ""Кеннет Рогофф Кеннет Рогофф Що відбувається в економіці головних країн ЄС на тлі приходу Трампа"":
  - img ""Кеннет Рогофф""
  - text: Кеннет Рогофф Що відбувається в економіці головних країн ЄС на тлі приходу Трампа
- link ""Ірина Геращенко Ірина Геращенко Чому Кремль обвалив рубль"":
  - img ""Ірина Геращенко""
  - text: Ірина Геращенко Чому Кремль обвалив рубль
- link ""Олександр Коваленко Олександр Коваленко Удар по Україні 28 листопада був дорозвідувальним. Основні ще готуються"":
  - img ""Олександр Коваленко""
  - text: Олександр Коваленко Удар по Україні 28 листопада був дорозвідувальним. Основні ще готуються
- 'link ""Робітник йде теплоелектростанцією, яка пошкоджена російським ракетним ударом 28 листопада 2024 року (Фото: REUTERS/Gleb Garanich) «Важко, але йдемо далі» / Ворог застосовує «принцип салямі», відрізаючи міста від світла: як це загрозжує ядерній безпеці — інтерв''ю NV 29 листопада, 16:45""':
  - 'img ""Робітник йде теплоелектростанцією, яка пошкоджена російським ракетним ударом 28 листопада 2024 року (Фото: REUTERS/Gleb Garanich)""'
  - text: ""«Важко, але йдемо далі» / Ворог застосовує «принцип салямі», відрізаючи міста від світла: як це загрозжує ядерній безпеці — інтерв'ю NV 29 листопада, 16:45""
- text: Новини
- list:
  - listitem:
    - link ""Останнє""
  - listitem:
    - link ""Головне""
  - listitem:
    - link ""Популярне""
- text: 17:01
- link ""Зеленський призначив Михайла Драпатого новим командувачем Сухопутних військ""
- text: 17:00
- link ""Уперше за 50 років. Учені представили нові ліки від астми — і вони ефективніші та безпечніші за нинішні препарати"": Уперше за 50 років. Учені представили нові ліки від астми — і вони ефективніші та безпечніші за нинішні препарати
- text: Новини компаній
- 'link ""Оновлення іміджу лідера української освіти Study.ua: що змінилося?""': ""Оновлення іміджу лідера української освіти Study.ua: що змінилося?""
- text: 17:00
- link ""Викрадені дані можуть злити в інтернет. Екссуперник Шахтаря у Лізі чемпіонів став жертвою кібератаки""
- text: 16:56
- link ""Обраний президент Євроради під час першого виступу згадав мир в Україні, який має «базуватися на міжнародному праві»"": Обраний президент Євроради під час першого виступу згадав мир в Україні, який має «базуватися на міжнародному праві»
- text: 16:56
- link ""«Якщо так триватиме далі, ми програємо». Ситуація на фронті складна, у нас немає інструментів для зміни траєкторії подій — Кулеба"": «Якщо так триватиме далі, ми програємо». Ситуація на фронті складна, у нас немає інструментів для зміни траєкторії подій — Кулеба
- text: 16:54
- link ""В Ізраїлі заявили, що їхні військові залишатимуться у Газі кілька років"": В Ізраїлі заявили, що їхні військові залишатимуться у Газі кілька років
- text: 16:54 Новини компаній
- 'link ""Приватбанк запускає Зелену п’ятницю: вигоди до 20%""': ""Приватбанк запускає Зелену п’ятницю: вигоди до 20%""
- text: 16:52
- link ""У Швеції невідомі скинули з дрона фарбу на посольство Росії"": У Швеції невідомі скинули з дрона фарбу на посольство Росії
- text: 16:47
- 'link ""«Не було іншого нападника»: тренер Яремчука пояснив несподівану втрату очків у Лізі Європи, згадавши про травму українця""': ""«Не було іншого нападника»: тренер Яремчука пояснив несподівану втрату очків у Лізі Європи, згадавши про травму українця""
- text: 16:47
- link ""Смак Луганщини. Як вимушена переселенка готує у центрі Львова французькі крепи (плюс оригінальний рецепт для великої родини)"": Смак Луганщини. Як вимушена переселенка готує у центрі Львова французькі крепи (плюс оригінальний рецепт для великої родини)
- text: 16:45
- 'link ""«Важко, але йдемо далі». Ворог застосовує «принцип салямі», відрізаючи міста від світла: як це загрозжує ядерній безпеці — інтерв''ю NV""': ""«Важко, але йдемо далі». Ворог застосовує «принцип салямі», відрізаючи міста від світла: як це загрозжує ядерній безпеці — інтерв'ю NV""
- text: 16:38
- link ""«Влада обрала шлях їсти г***но». Депутат розповів про «найпровальніший» закон України — про що всі боялися сказати президенту"": «Влада обрала шлях їсти г***но». Депутат розповів про «найпровальніший» закон України — про що всі боялися сказати президенту
- text: 16:30
- link ""«Не до кінця відчуває». Олександр Ярмак розповів про конфлікти з дружиною, які виникають на тлі його служби у війську"": «Не до кінця відчуває». Олександр Ярмак розповів про конфлікти з дружиною, які виникають на тлі його служби у війську
- text: 16:23
- link ""Шокував суперника. Футболіст клубу української Прем'єр-ліги забив фантастичний гол на 19-й секунді матчу — відео"": Шокував суперника. Футболіст клубу української Прем'єр-ліги забив фантастичний гол на 19-й секунді матчу — відео
- text: 16:22
- link ""Для захисту вузла поставок Україні. Міноборони Німеччини підтвердило, що хоче повторно розмістити Patriot у Польщі"": Для захисту вузла поставок Україні. Міноборони Німеччини підтвердило, що хоче повторно розмістити Patriot у Польщі
- link ""Всі новини""
- 'link ""Михайло Драпатий (Фото: Wikimedia Commons) Зеленський призначив Михайла Драпатого новим командувачем Сухопутних військ""':
  - 'img ""Михайло Драпатий (Фото: Wikimedia Commons)""'
  - text: Зеленський призначив Михайла Драпатого новим командувачем Сухопутних військ
- 'link ""У 2025 році всі чоловіки віком 18−25 років повинні пройти військову підготовку (Фото: facebook.com/okPivden/) «В першу чергу студенти» / Наступного року всі чоловіки віком від 18 до 25 років повинні пройти військову підготовку — Сухопутні війська 29 листопада, 16:13 Події""':
  - 'img ""У 2025 році всі чоловіки віком 18−25 років повинні пройти військову підготовку (Фото: facebook.com/okPivden/)""'
  - text: «В першу чергу студенти» / Наступного року всі чоловіки віком від 18 до 25 років повинні пройти військову підготовку — Сухопутні війська 29 листопада, 16:13 Події
- 'link ""Росія посилює брязкання ядерною зброєю (Фото: REUTERS/Evgenia Novozhenina) «Путін не зупиниться» / Глава британської розвідки попередив про наслідки в разі перемоги РФ у війні проти України 29 листопада, 15:56 Геополітика""':
  - 'img ""Росія посилює брязкання ядерною зброєю (Фото: REUTERS/Evgenia Novozhenina)""'
  - text: «Путін не зупиниться» / Глава британської розвідки попередив про наслідки в разі перемоги РФ у війні проти України 29 листопада, 15:56 Геополітика
- 'link ""Собор Паризької Богоматері, 29 листопада 2024 року (Фото: STEPHANE DE SAKUTIN/Pool via REUTERS) Фоторепортаж / Собор Паризької Богоматері відкриють 8 грудня — перші фото з оновленого Нотр-Даму після пожежі 29 листопада, 15:51 Країни""':
  - 'img ""Собор Паризької Богоматері, 29 листопада 2024 року (Фото: STEPHANE DE SAKUTIN/Pool via REUTERS)""'
  - text: Фоторепортаж / Собор Паризької Богоматері відкриють 8 грудня — перші фото з оновленого Нотр-Даму після пожежі 29 листопада, 15:51 Країни
- 'link ""Володимир Путін в Астані, 28 листопада 2024 (Фото: Sputnik/Mikhail Tereschenko/Pool via REUTERS) Сюжет Орешником по Києву і «стерти в пил» / Чи повірив світ у нові погрози Путіна — оцінки міжнародних медіа 29 листопада, 12:07 Геополітика""':
  - 'img ""Володимир Путін в Астані, 28 листопада 2024 (Фото: Sputnik/Mikhail Tereschenko/Pool via REUTERS)""'
  - text: Сюжет Орешником по Києву і «стерти в пил» / Чи повірив світ у нові погрози Путіна — оцінки міжнародних медіа 29 листопада, 12:07 Геополітика
- 'link ""21 листопада Рада прийняла закон про добровільне повернення на військову службу після першого СЗЧ (Фото: REUTERS/Serhiy Takhmazov) У військових є час до 1 січня, щоб повернутися із СЗЧ без несення кримінальної відповідальності — ДБР 29 листопада, 15:27 Події""':
  - 'img ""21 листопада Рада прийняла закон про добровільне повернення на військову службу після першого СЗЧ (Фото: REUTERS/Serhiy Takhmazov)""'
  - text: У військових є час до 1 січня, щоб повернутися із СЗЧ без несення кримінальної відповідальності — ДБР 29 листопада, 15:27 Події
- 'link ""Мобілізація (Фото: Генштаб ЗСУ / Facebook) «Ми не стали б втручатися» / Німеччина заперечує, що пропонувала Києву знизити призовний вік 29 листопада, 15:01 Геополітика""':
  - 'img ""Мобілізація (Фото: Генштаб ЗСУ / Facebook)""'
  - text: «Ми не стали б втручатися» / Німеччина заперечує, що пропонувала Києву знизити призовний вік 29 листопада, 15:01 Геополітика
- 'link ""Лідер Північної Кореї Кім Чен Ин передав Росії сотню балістичних ракет і десятки артсистем (Фото: KCNA via REUTERS) КНДР передала Росії десятки САУ Koksan і близько 100 балістичних ракет KN-23/24 — ГУР 29 листопада, 14:41 Геополітика""':
  - 'img ""Лідер Північної Кореї Кім Чен Ин передав Росії сотню балістичних ракет і десятки артсистем (Фото: KCNA via REUTERS)""'
  - text: КНДР передала Росії десятки САУ Koksan і близько 100 балістичних ракет KN-23/24 — ГУР 29 листопада, 14:41 Геополітика
- 'link ""Вулиця у Ківшарівці, лівий берег річки Оскіл (Фото: Сергій Окунєв / NV) Гучний Куп’янськ / Журналіст NV відвідав ділянку фронту, про «оточення» якої оголошував особисто Путін 29 листопада, 10:10 Події""':
  - 'img ""Вулиця у Ківшарівці, лівий берег річки Оскіл (Фото: Сергій Окунєв / NV)""'
  - text: Гучний Куп’янськ / Журналіст NV відвідав ділянку фронту, про «оточення» якої оголошував особисто Путін 29 листопада, 10:10 Події
- 'link ""Аналітики проаналізували дані про нові вибухи на окупованому півострові (Фото: КіберБорошно / Telegram) В окупованому Криму уразили, ймовірно, позицію С-400 Тріумф — OSINT-аналітики 29 листопада, 14:39 Події""':
  - 'img ""Аналітики проаналізували дані про нові вибухи на окупованому півострові (Фото: КіберБорошно / Telegram)""'
  - text: В окупованому Криму уразили, ймовірно, позицію С-400 Тріумф — OSINT-аналітики 29 листопада, 14:39 Події
- 'link ""Диктатор РФ Володимир Путін (Фото: Sputnik/Mikhail Klimentyev/Kremlin via REUTERS) Кремль почав видаляти метадані з усіх відео за участю Путіна 29 листопада, 14:21 Країни""':
  - 'img ""Диктатор РФ Володимир Путін (Фото: Sputnik/Mikhail Klimentyev/Kremlin via REUTERS)""'
  - text: Кремль почав видаляти метадані з усіх відео за участю Путіна 29 листопада, 14:21 Країни
- 'link ""Глава ГУР Міноборони України Кирило Буданов (Фото: NV) Буданов відреагував на погрози Путіна щодо використання проти українців нових ракет 29 листопада, 11:51 Події""':
  - 'img ""Глава ГУР Міноборони України Кирило Буданов (Фото: NV)""'
  - text: Буданов відреагував на погрози Путіна щодо використання проти українців нових ракет 29 листопада, 11:51 Події
- 'link ""Тіла понад 500 загиблих військових повернули на територію України (Фото: Генштаб ЗСУ) Україна повернула тіла 502 полеглих військових 29 листопада, 13:31 Події""':
  - 'img ""Тіла понад 500 загиблих військових повернули на територію України (Фото: Генштаб ЗСУ)""'
  - text: Україна повернула тіла 502 полеглих військових 29 листопада, 13:31 Події
- 'link ""Нафтобаза Атлас, що палає в Ростовській області після атаки дронів, 29 листопада 2024 року (Фото: скріншот із відео / Telegram) Генштаб підтвердив ураження нафтобази у Ростовській області РФ та знищення російського ЗРК Бук-М3 29 листопада, 11:02 Країни""':
  - 'img ""Нафтобаза Атлас, що палає в Ростовській області після атаки дронів, 29 листопада 2024 року (Фото: скріншот із відео / Telegram)""'
  - text: Генштаб підтвердив ураження нафтобази у Ростовській області РФ та знищення російського ЗРК Бук-М3 29 листопада, 11:02 Країни
- text: ""Реклама:""
- 'link ""Українські військові (Фото: 18-та Слов’янська бригада Національної гвардії) Прогледіли чи ні? / Під час останньої ракетної атаки РФ були пошкоджені важливі об''єкти. Чи є тут провина ППО — аналіз NV 28 листопада, 18:25""':
  - 'img ""Українські військові (Фото: 18-та Слов’янська бригада Національної гвардії)""'
  - text: Прогледіли чи ні? / Під час останньої ракетної атаки РФ були пошкоджені важливі об'єкти. Чи є тут провина ППО — аналіз NV 28 листопада, 18:25
- 'link ""Втрата надійного джерела коксівного вугілля посилить несприятливу ситуацію для металургійної галузі України (Фото: pokrovskoe.metinvestholding.com) «Єдиний рецепт — зупинити ворога» / Як втрата Покровська може змінити металургійну галузь України — розбір NV Бізнес 28 листопада, 07:58 Економіка""':
  - 'img ""Втрата надійного джерела коксівного вугілля посилить несприятливу ситуацію для металургійної галузі України (Фото: pokrovskoe.metinvestholding.com)""'
  - text: «Єдиний рецепт — зупинити ворога» / Як втрата Покровська може змінити металургійну галузь України — розбір NV Бізнес 28 листопада, 07:58 Економіка
- 'link ""Падіння курсу рубля співпало з початком ударів по російський теріторії ракетами західного виробництва (Фото: minfin.com.ua) Сюжет Удар далекобійною зброєю / Що означає рекордне знецінення російського рубля щодо долара 28 листопада, 09:00 Фінанси""':
  - 'img ""Падіння курсу рубля співпало з початком ударів по російський теріторії ракетами західного виробництва (Фото: minfin.com.ua)""'
  - text: Сюжет Удар далекобійною зброєю / Що означає рекордне знецінення російського рубля щодо долара 28 листопада, 09:00 Фінанси
- 'link ""Директор з інновацій NovaPay Олексій Рубан розповів про плани платіжної системи стати інклюзивним банком (Фото: NV/Олександр Медвєдєв) «В Європі не можна так, як в Україні» / Як NovaPay готується стати банком — інтерв''ю з інноватором фінтех-стартапу Нової пошти 27 листопада, 10:31 Фінанси""':
  - 'img ""Директор з інновацій NovaPay Олексій Рубан розповів про плани платіжної системи стати інклюзивним банком (Фото: NV/Олександр Медвєдєв)""'
  - text: «В Європі не можна так, як в Україні» / Як NovaPay готується стати банком — інтерв'ю з інноватором фінтех-стартапу Нової пошти 27 листопада, 10:31 Фінанси
- 'link ""Складна економічна ситуація, а також хитка та проблемна коаліція можуть призвести до відставки Шольца (Фото: REUTERS/Annegret Hilse) Шольц зробив свою справу, Шольц має йти / Чому Німеччина йде на дострокові вибори і хто може стати наступним її канцлером 29 листопада, 07:08""':
  - 'img ""Складна економічна ситуація, а також хитка та проблемна коаліція можуть призвести до відставки Шольца (Фото: REUTERS/Annegret Hilse)""'
  - text: Шольц зробив свою справу, Шольц має йти / Чому Німеччина йде на дострокові вибори і хто може стати наступним її канцлером 29 листопада, 07:08
- heading ""Не пропустіть"" [level=2]:
  - link ""Не пропустіть""
- 'link ""Історик Ярослав Грицак (Фото: Roman Naumov / Facebook) «Настав етап, коли вже все можливо» / Коли в РФ з’явився план поділу України і як Путін хоче його втілити до 2045-го — інтерв''ю з Ярославом Грицаком""':
  - 'img ""Історик Ярослав Грицак (Фото: Roman Naumov / Facebook)""'
  - text: «Настав етап, коли вже все можливо» / Коли в РФ з’явився план поділу України і як Путін хоче його втілити до 2045-го — інтерв'ю з Ярославом Грицаком
- 'link ""Цех російського військового заводу Уралвагонзавод (Фото: Reuters) Стань банкрутом заради Росії / Як російський уряд дивним чином стримує зростання цін, — Ліпсіц 29 листопада, 14:17 Геополітика""':
  - 'img ""Цех російського військового заводу Уралвагонзавод (Фото: Reuters)""'
  - text: Стань банкрутом заради Росії / Як російський уряд дивним чином стримує зростання цін, — Ліпсіц 29 листопада, 14:17 Геополітика
- 'link ""Російський диктатор Володимир Путін на саміті ОДКБ в Казахстані 28 листопада (Фото: Sputnik/Ramil Sitdikov/Kremlin via REUTERS) «Розхитують ситуацію» / Чи готується Путін знову застосувати Орешник і який «ред флег» про це свідчитиме — Ступак 29 листопада, 14:14 Події""':
  - 'img ""Російський диктатор Володимир Путін на саміті ОДКБ в Казахстані 28 листопада (Фото: Sputnik/Ramil Sitdikov/Kremlin via REUTERS)""'
  - text: «Розхитують ситуацію» / Чи готується Путін знову застосувати Орешник і який «ред флег» про це свідчитиме — Ступак 29 листопада, 14:14 Події
- 'link ""Керівник ГУР Кирило Буданов (Фото: NV) Буданов під загрозою / Джерело NV розповіло, що на Банковій вже вдруге планують звільнити керівника ГУР і знайшли кандидата на заміну 25 листопада, 19:30 Політика""':
  - 'img ""Керівник ГУР Кирило Буданов (Фото: NV)""'
  - text: Буданов під загрозою / Джерело NV розповіло, що на Банковій вже вдруге планують звільнити керівника ГУР і знайшли кандидата на заміну 25 листопада, 19:30 Політика
- 'link ""В рамках заходу NV «Україна 2050. Діалоги про майбутнє» відбулася дискусійна панель під назвою «На мапі світу» за участі посолки Канади в Україні Наталки Цмоць, посла Німеччини Мартіна Єґера та посла Великої Британії в Україні Мартіна Гарріса (Фото: Сергій Канциренко/NV) «Майбутнє України — в НАТО» / Посли Німеччини, Великої Британії та Канади — про те, як має закінчитися війна та що чекає Україну 29 листопада, 11:55 Події""':
  - 'img ""В рамках заходу NV «Україна 2050. Діалоги про майбутнє» відбулася дискусійна панель під назвою «На мапі світу» за участі посолки Канади в Україні Наталки Цмоць, посла Німеччини Мартіна Єґера та посла Великої Британії в Україні Мартіна Гарріса (Фото: Сергій Канциренко/NV)""'
  - text: «Майбутнє України — в НАТО» / Посли Німеччини, Великої Британії та Канади — про те, як має закінчитися війна та що чекає Україну 29 листопада, 11:55 Події
- 'link ""Боєць бригади Азов, колишній військовополонений Геннадій Харченко в студії Radio NV (Фото: Скріншот відео/Youtube Radio NV) «До цього не був готовий» / Азовець Харченко в інтерв''ю розповів про перебування в російському полоні і важке рішення командира Редіса 29 листопада, 11:53 Події""':
  - 'img ""Боєць бригади Азов, колишній військовополонений Геннадій Харченко в студії Radio NV (Фото: Скріншот відео/Youtube Radio NV)""'
  - text: «До цього не був готовий» / Азовець Харченко в інтерв'ю розповів про перебування в російському полоні і важке рішення командира Редіса 29 листопада, 11:53 Події
- link ""Олег Вишняков Олег Вишняков Власник мережі гіпермаркетів Ultramarket (Мегамаркет)"":
  - img ""Олег Вишняков""
  - text: Олег Вишняков Власник мережі гіпермаркетів Ultramarket (Мегамаркет)
- 'link ""Зростання цін на продукти в Україні: Що відбувається? Прогноз подорожчання базових продуктів вже озвучений на офіційному рівні, та й по деяких видах товарів ми вже почали його помічати в магазинах. Що буде далі? 29 листопада, 11:14 Експерти""':
  - text: ""Зростання цін на продукти в Україні: Що відбувається?""
  - paragraph: Прогноз подорожчання базових продуктів вже озвучений на офіційному рівні, та й по деяких видах товарів ми вже почали його помічати в магазинах. Що буде далі?
  - text: 29 листопада, 11:14 Експерти
- 'link ""В Україні - п’ять доларових міліардерів (Фото: Колаж NV) Ахметов, Пінчук, Порошенко / NV називає топ-30 найбагатших українців — хто потрапив до рейтингу 26 листопада, 08:10""':
  - 'img ""В Україні - п’ять доларових міліардерів (Фото: Колаж NV)""'
  - text: Ахметов, Пінчук, Порошенко / NV називає топ-30 найбагатших українців — хто потрапив до рейтингу 26 листопада, 08:10
- heading ""Бiзнес"" [level=2]:
  - link ""Бiзнес""
- 'link ""Ярослав Железняк розповів, що не так із податковим законом (Фото: Прес-служба ВРУ) «Влада обрала шлях їсти г***но» / Депутат розповів про найбільш «провальний» закон України — про що всі боялися сказати президенту""':
  - 'img ""Ярослав Железняк розповів, що не так із податковим законом (Фото: Прес-служба ВРУ)""'
  - text: «Влада обрала шлях їсти г***но» / Депутат розповів про найбільш «провальний» закон України — про що всі боялися сказати президенту
- 'link ""Російський диктатор Володимир Путін (Фото: Alexander Zemlianichenko / Pool via REUTERS) Кремлівська багатоходівка / Обвал рубля може допомогти Путіну у війні проти України — BILD 29 листопада, 16:02 Економіка""':
  - 'img ""Російський диктатор Володимир Путін (Фото: Alexander Zemlianichenko / Pool via REUTERS)""'
  - text: Кремлівська багатоходівка / Обвал рубля може допомогти Путіну у війні проти України — BILD 29 листопада, 16:02 Економіка
- 'link ""Готель Україна (Фото: Ола Файн) Велика приватизація / Антимонопольний комітет дозволив компанії Максима Кріппи купити готель Україна 29 листопада, 15:06 Ритейл/Нерухомість""':
  - 'img ""Готель Україна (Фото: Ола Файн)""'
  - text: Велика приватизація / Антимонопольний комітет дозволив компанії Максима Кріппи купити готель Україна 29 листопада, 15:06 Ритейл/Нерухомість
- 'link ""Кремль (Фото: REUTERS/Maxim Zmeyev/File Photo) Під тиском США / Традиційний союзник Путіна ще більше ускладнив життя російському бізнесу 29 листопада, 14:32 Економіка""':
  - 'img ""Кремль (Фото: REUTERS/Maxim Zmeyev/File Photo)""'
  - text: Під тиском США / Традиційний союзник Путіна ще більше ускладнив життя російському бізнесу 29 листопада, 14:32 Економіка
- 'link ""Ярослав Железняк (Фото: Ярослав Железняк / Facebook) «Погодили найгірший варіант» / Железняк заявив, що в підписанні податкового закону немає логіки — що не так 29 листопада, 14:30 Компанії / Ринки""':
  - 'img ""Ярослав Железняк (Фото: Ярослав Железняк / Facebook)""'
  - text: «Погодили найгірший варіант» / Железняк заявив, що в підписанні податкового закону немає логіки — що не так 29 листопада, 14:30 Компанії / Ринки
- 'link ""Олег Гоцинець (Фото: Facebook Олега Гоцинця) Кабмін призначив очільника Держгеонадр 29 листопада, 13:16 Економіка""':
  - 'img ""Олег Гоцинець (Фото: Facebook Олега Гоцинця)""'
  - text: Кабмін призначив очільника Держгеонадр 29 листопада, 13:16 Економіка
- 'link ""Денис Шмигаль (Фото: Уряд України) «Ситуація складна» / Шмигаль розповів про стан енергосистеми України 29 листопада, 13:13 Компанії / Ринки""':
  - 'img ""Денис Шмигаль (Фото: Уряд України)""'
  - text: «Ситуація складна» / Шмигаль розповів про стан енергосистеми України 29 листопада, 13:13 Компанії / Ринки
- heading ""Погляди"" [level=2]:
  - link ""Погляди""
- 'link ""Тімоті Еш: Це типовий почерк Путіна — ескалація перед переговорами (Фото: REUTERS)""':
  - 'img ""Тімоті Еш: Це типовий почерк Путіна — ескалація перед переговорами (Фото: REUTERS)""'
- link ""Тімоті Еш Тімоті Еш Британський економіст, експерт з питань України"":
  - img ""Тімоті Еш""
  - text: Тімоті Еш Британський економіст, експерт з питань України
- link ""Сміливець! / Ось у чому полягає гра Путіна. П’ять тез про ядерну зброю"": Сміливець! / Ось у чому полягає гра Путіна. П’ять тез про ядерну зброю
- text: 22 листопада, 15:53
- link ""Сергій Фурса Сергій Фурса Колумніст, інвестиційний банкір"":
  - img ""Сергій Фурса""
  - text: Сергій Фурса Колумніст, інвестиційний банкір
- link ""Політ рубля та плани Путіна влаштувати чорну п’ятницю в Україні На тлі кволого тижня на світових ринках найбільшою розвагою було спостереження за російським рублем 29 листопада, 12:55 Погляди"":
  - text: Політ рубля та плани Путіна влаштувати чорну п’ятницю в Україні
  - paragraph: На тлі кволого тижня на світових ринках найбільшою розвагою було спостереження за російським рублем
  - text: 29 листопада, 12:55 Погляди
- link ""Олексій Мельник Олексій Мельник Військовий експерт"":
  - img ""Олексій Мельник""
  - text: Олексій Мельник Військовий експерт
- link ""Трамп визначився. Що стало зрозуміло про закінчення війни в Україні Тепер ми знаємо, хто у Трампа відповідатиме за майбутнє врегулювання російсько-української війни та яким він бачить її закінчення 29 листопада, 12:45 Погляди"":
  - text: Трамп визначився. Що стало зрозуміло про закінчення війни в Україні
  - paragraph: Тепер ми знаємо, хто у Трампа відповідатиме за майбутнє врегулювання російсько-української війни та яким він бачить її закінчення
  - text: 29 листопада, 12:45 Погляди
- link ""Павло Баєв Павло Баєв Норвезький політолог"":
  - img ""Павло Баєв""
  - text: Павло Баєв Норвезький політолог
- link ""Три ескалації Путіна. На що зробив ставку Кремль У листопаді президент Росії Володимир Путін вирішив зробити три демонстративні ескалаційні кроки 29 листопада, 10:33 Погляди"":
  - text: Три ескалації Путіна. На що зробив ставку Кремль
  - paragraph: У листопаді президент Росії Володимир Путін вирішив зробити три демонстративні ескалаційні кроки
  - text: 29 листопада, 10:33 Погляди
- link ""Наташа Ліндштедт Наташа Ліндштедт Професорка кафедри державного управління Ессекського університету, Англія"":
  - img ""Наташа Ліндштедт""
  - text: Наташа Ліндштедт Професорка кафедри державного управління Ессекського університету, Англія
- link ""У Путіна закінчуються люди. Що відбувається з мобілізацією в Росії Було б помилкою вважати, що Путін підходить до столу переговорів з позиції сили 29 листопада, 10:15 Погляди"":
  - text: У Путіна закінчуються люди. Що відбувається з мобілізацією в Росії
  - paragraph: Було б помилкою вважати, що Путін підходить до столу переговорів з позиції сили
  - text: 29 листопада, 10:15 Погляди
- 'link ""Джонатан Хакун: «Рух покращує роботу мозку» (Фото: ljsphotography/Depositphotos)""':
  - 'img ""Джонатан Хакун: «Рух покращує роботу мозку» (Фото: ljsphotography/Depositphotos)""'
- link "" Як впливають на мозок легкі фізичні навантаження"":  Як впливають на мозок легкі фізичні навантаження
- link ""Джонатан Хакун""
- heading ""Промокоди"" [level=2]:
  - link ""Промокоди""
- link ""iHerb / Купони на знижку""
- link ""AliExpress / Купони на знижки""
- link ""Touch / Свіжі пропозиції, знижки""
- contentinfo:
  - list:
    - listitem:
      - link ""Карта сайту""
    - listitem:
      - link ""Всі колумністи NV""
    - listitem:
      - link ""Всі Лідери думок""
    - listitem:
      - link ""Всі техноблогери""
    - listitem:
      - link ""Всі експерти NV Бізнес""
    - listitem:
      - link ""Автори та редактори сайту""
  - list:
    - listitem:
      - link ""Редакційна політика""
    - listitem:
      - link ""Про нас""
    - listitem:
      - link ""Блог NV""
    - listitem:
      - link ""Контакти""
    - listitem:
      - link ""Правила використання""
    - listitem:
      - link ""Договір користування""
    - listitem:
      - link ""Вакансії""
  - link ""наш twitter"": 
  - link ""наш instagram"": 
  - link ""наш telegram"": 
  - link ""наш youtube"": 
  - link ""наш facebook"": 
  - link ""наш facebook"": 
  - link ""наш tiktok"": 
  - text: Додаток NV
  - paragraph: Developed by Apiko
  - link ""poster"":
    - img ""poster""
  - link ""poster"":
    - img ""poster""
  - list:
    - listitem:
      - link ""Україна""
    - listitem:
      - link ""Київ""
    - listitem:
      - link ""Світ""
  - list:
    - listitem:
      - link ""Бізнес""
      - link """"
    - listitem:
      - link ""Погляди""
      - link """"
    - listitem:
      - link ""Відео""
  - list:
    - listitem:
      - link ""Техно""
      - link """"
    - listitem:
      - link ""Авто""
    - listitem:
      - link ""Спорт""
  - list:
    - listitem:
      - link ""LIFE""
      - link """"
      - link """"
    - listitem:
      - link ""Food""
      - link """"
      - link """"
  - list:
    - listitem:
      - link ""Шопінг""
      - link """"
    - listitem:
      - link ""Промокоди""
    - listitem:
      - link ""LOL""
  - list:
    - listitem:
      - link ""Лонгріди""
    - listitem:
      - link ""Картки""
    - listitem:
      - link ""Журнал""
  - list:
    - listitem:
      - link ""NV Подкасти""
      - link """"
      - link """"
      - link """"
    - listitem:
      - link ""Радіо""
      - link """"
      - link """"
    - listitem:
      - link ""Email-розсилки""
  - text: Слухайте нас
  - link ""poster"":
    - img ""poster""
  - link ""poster"":
    - img ""poster""
  - link ""poster"":
    - img ""poster""
  - link """"
  - link """"
  - link """"
  - link ""Mixcloud""
  - text: NV Подкасти
  - paragraph: Developed by Apiko
  - link ""poster"":
    - img ""poster""
  - link ""poster"":
    - img ""poster""
  - paragraph: Е-mail редакції
  - link ""news@nv.ua""
  - paragraph: Відділ реклами
  - link ""sales@nv.ua""
  - paragraph: Радіо
  - link ""radionv@nv.ua""
  - paragraph: E-mail журналу
  - link ""letters@nv.ua""
  - paragraph: Подкасти
  - link ""podcasts@nv.ua""
  - paragraph: Відділ підтримки
  - link ""support@nv.ua""
  - paragraph: ""Політична реклама:""
  - text: Позиція
  - paragraph: ""Матеріали, відмічені значками, публікуються на правах реклами:""
  - text: Реклама Новини компаній PR Партнерський проєкт Позиція Вони наближають перемогу Спецпроект - актуальний до 16.07.2021
  - paragraph: Стокові фото
  - link ""poster"":
    - img ""poster""
  - paragraph: Твори Getty Images, що розміщені на сайті, не можуть бути використані третіми особами без письмового дозволу редакції сайту.
  - paragraph: Незалежна сертифікація відповідно до програми JTI та CWA
  - paragraph: Якщо ви знайшли помилку в тексті, виділіть її мишкою і натисніть Ctrl + Enter
  - paragraph:
    - text: Використання матеріалів сайту можливе за умови дотримання Правил користування сайтом і правил використання матеріалів сайту. Усі матеріали, які розміщені на цьому сайті із посиланням на агентство
    - link ""\""Інтерфакс-Україна\""""
    - text: "", не підлягають подальшому відтворенню та/чи розповсюдженню в будь-якій формі, інакше як з письмового дозволу агентства \""Інтерфакс-Україна\"". Передрук, копіювання або відтворення інформації, яка містить посилання на агентство""
    - link ""ИнА “Українські Новини”""
    - text: "", в будь-якому вигляді суворо заборонено, гіперпосилання на логотип «Українські Новини» обов’язкове. Цей ресурс — для користувачів віком від 18 років і старших. Матеріали, в тексті (після тексту) яких міститься заборона на повне републікування (передрук, копіювання, відтворення або інше використання), або матеріали, доступ до яких є платним, дозволяється використовувати частково. Обсяг використання не може перевищувати 25% від загального обсягу тексту. Таке часткове використання дозволяється виключно за наявності гіперпосилання в кінці текстових матеріалів з підписом: «Повну версію читайте на nv.ua».""
  - paragraph: © 2014 - 2024, ТОВ «ВИДАВНИЧИЙ ДІМ «МЕДІА-ДК». Всі права захищені. Cуб’єкт у сфері онлайн-медіа; ідентифікатор медіа – R40-02145
- paragraph: Про використання cookies
- paragraph: Продовжуючи переглядати NV.ua ви підтверджуєте, що ознайомилися з Правилами користування сайтом та погоджуєтеся на використання файлів cookies
- link ""Про файли cookies""
- button ""Погоджуюсь""
- button """"
- link
            ");
        }


        [Test]
        public async Task UZ()
        {
            await Page.GotoAsync("https://uz.gov.ua/");

            var locator = Page.Frame("callme").Locator("#liracrm_form_name");
            await locator.WaitForAsync();
            await Assertions.Expect(locator).ToHaveAccessibleNameAsync("Ім’я");

            await Assertions.Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync(@"
- link ""Пропустити навігацію""
- banner: Укрзалізниця
- list:
  - listitem: укр
  - listitem:
    - link ""eng""
- heading ""Налаштування кольорів та шрифтів"" [level=2]
- button ""Налаштувати кольори та шрифти""
- heading ""Розділ - Особам з інвалідністю"" [level=2]
- link ""Розділ - Особам з інвалідністю"":
  - img
- link ""→Мапа сайту""
- heading ""Форма пошуку на сайті"" [level=2]
- search:
  - group:
    - textbox
    - button ""Пошук""
- navigation:
  - heading ""Головне меню"" [level=2]
  - list:
    - listitem:
      - heading ""Про нас"" [level=2]:
        - link ""Про нас""
    - listitem:
      - heading ""Пасажирам"" [level=2]:
        - link ""Пасажирам""
    - listitem:
      - heading ""Вантажні перевезення"" [level=2]:
        - link ""Вантажні перевезення""
    - listitem:
      - heading ""Робота на залізниці"" [level=2]:
        - link ""Робота на залізниці""
    - listitem:
      - heading ""Прес-центр"" [level=2]:
        - link ""Прес-центр""
    - listitem:
      - heading ""Контакти/Зворотний зв'язок"" [level=2]:
        - link ""Контакти/Зворотний зв'язок""
- main:
  - heading ""Слайдер — важливе на сайті"" [level=2]
  - paragraph:
    - link ""Пропустити слайдер""
  - list:
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
    - listitem:
      - link:
        - img
  - list:
    - listitem
    - listitem
    - listitem
    - listitem
    - listitem
    - listitem
    - listitem
    - listitem
  - heading ""Новини"" [level=1]:
    - link ""Новини""
  - text: ""[28.11.2024]""
  - heading ""На 92 вокзалах України працюють пункти незламності"" [level=2]:
    - link ""На 92 вокзалах України працюють пункти незламності""
  - text: Укрзалізниця запрошує всіх, хто через ворожі обстріли залишився без електрики, підзарядити свої гаджети та випити гарячого чаю в залізничних пунктах незламності. Вони функціонують на 92 вокзалах по всій Україні. [21.11.2024]
  - heading ""Укрзалізниця запускає новий поїзд Київ – Будапешт"" [level=2]:
    - link ""Укрзалізниця запускає новий поїзд Київ – Будапешт""
  - text: Анонсуємо новий зручний маршрут до ЄС! В новому графіку руху з 15 грудня почне курсувати поїзд №9/10 з Києва до Будапешта – великого залізничного та авіаційного хаба.
  - paragraph:
    - link
- complementary:
  - paragraph:
    - link
  - paragraph:
    - link
  - paragraph:
    - link
  - paragraph:
    - link
  - paragraph:
    - link
  - paragraph:
    - link
- img
- paragraph:
  - link
- heading [level=1]:
  - strong
- paragraph
- heading ""Договір"" [level=1]
- link ""надання безповоротної фінансової допомоги"":
  - heading ""надання безповоротної фінансової допомоги"" [level=2]
- heading [level=2]:
  - strong
- paragraph:
  - strong
- heading ""Щодо форс-мажорних обставин"" [level=2]:
  - link ""Щодо""
  - link ""форс-мажорних""
  - link ""обставин""
- heading ""(обставин непереборної сили) – військової агресії російської федерації проти України"" [level=3]:
  - link ""(обставин непереборної сили) – військової агресії російської федерації проти України""
- paragraph
- link ""Кіберполіція запрошує долучитись до соціального проєкту BRAMA"":
  - img ""Кіберполіція запрошує долучитись до соціального проєкту BRAMA""
- paragraph:
  - link
- heading ""Укрзалізниця у соціальних мережах"" [level=2]
- link ""Спілкуйтесь з нами на Фейсбуці"":
  - paragraph: Спілкуйтесь з нами на Фейсбуці
- link ""Є що подивитися на Youtube"":
  - paragraph: Є що подивитися на Youtube
- link ""Стежте за нами у Твітері"":
  - paragraph: Стежте за нами у Твітері
- link ""Дивитися сертифікат"":
  - img ""Дивитися сертифікат""
- link ""Дивитися сертифікат""
- link ""Дивитися сертифікат""
- paragraph:
  - link ""Дивитися сертифікат""
  - link ""Сайт адаптовано для людей з глибокими вадами зору""
- table:
  - rowgroup:
    - row:
      - cell:
        - paragraph
      - cell
    - row ""2012 © Всі права захищені"":
      - cell ""2012 © Всі права захищені""
            ");
        }
    }
}
