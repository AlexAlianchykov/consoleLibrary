# consoleLibrary
Это тренировочный проект, я решил его реализовать, чтобы наглядно протестировать как работают те или иные приёмы языка C#, о которых я прочёл в книге Джона Шарпа.  

## Основная задача проекта:
Основной задачей этого проекта была идея о реализации библиотеки(учебного заведения, куда школьники ходят брать книжки) в цифровом виде, на базе консольного приложения. 

Идея проста : 
Пользователь приходит в библиотеку –> ему выдают библиотечную книжку --> он благодаря книжке может совершать определённые действия  совершив действия он уходит из библиотеки

## Архитектура проекта:
Архитектура проекта была вдохновлена чистой архитектурой, но тут важно заметить слово вдохновлена)) Она состоит из 4 слоёв, тут всё так же как и в чистой архитектуре, каждый внутренний слой не знает о внешнем слое. 
<br>
![image](https://github.com/user-attachments/assets/f1a32439-2b85-4c71-a194-46a9d39278aa)
<br>

#### Layer 1 – состоит из двух максимально примитивных классов (в чистой архитектуре это был бы доменный слой со своими сущностями) Книга и Юзер.<br>
--> User - создание юзера (имя пароль)<br>
--> Book - создание книги (её название, автор, доступность)<br>
    
#### Layer 2 – состоит из классов которые непосредственно управляют классами первого слоя – Логин, Чтение книги, Библиотечная карточка.<br>
--> Login - Войти/зарегистрироваться<br>
--> LibraryСard - библиотечная карточка юзера (её номер, список книг которые он взял, инфа о юзере. Она управляет тем, что юзер берёт книгу или возвращает )<br>
--> ReadBook - чтение книги (какую книгу и когда взял юзер)<br>
    
#### Layer 3 – слой с классом Библиотека, управляющий работой всей библиотеки<br>
--> Library - библиотека(список библиотечных карточек, список книг. Она отвечает за создание новой книги, за создание библиотечной карточки , а так же за просмотр доступных книг)<br>
   
#### Layer 4 – программный слой управляющий работой всего приложения<br>
--> Program - отвечает за рпботу программы, проверяет выбор пользователя<br>


## Реализация работы проекта на практике:

1) Приветствие, предположим, что группа школьников заходит в библиотеку. Каждый школьник подходит к библиотекарю.
   ![image](https://github.com/user-attachments/assets/facc56f4-26bc-4d61-be14-7354d9c31378)
   <br>
2) Регистрация и получение библиотечных книжек:
   ![image](https://github.com/user-attachments/assets/904a3685-24c7-499c-9faa-5b659dbca374)
   <br>
3) Как только ваша книжка была создана, вы можете выбрать 1 из действий :
1. Пожертвовать книгу в библиотеку
2. Посмотреть список доступных книг
3. Взять книгу из библиотеки
4. Вернуть книгу в библиотеку
5. Посмотреть список взятых книг
6. Выйти из аккаунта




