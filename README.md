<div align="center">

# Лабораторная работа №2 по дисциплине "Алгоритмы и программирование"

![GitHub top language](https://img.shields.io/github/languages/top/tstu-artemos-projects/Lab2Algos?style=for-the-badge&logo=dotnet&color=8B00FF&logoColor=FFFFFF)
![GitHub repo size](https://img.shields.io/github/repo-size/tstu-artemos-projects/Lab2Algos?style=for-the-badge&logo=github&logoColor=FFFFFF)

![GitHub branch status](https://img.shields.io/github/check-runs/tstu-artemos-projects/Lab2Algos/master?style=for-the-badge&logo=githubactions&logoColor=FFFFFF)
![Last Commit](https://img.shields.io/github/last-commit/tstu-artemos-projects/Lab2Algos?style=for-the-badge&logo=git&logoColor=FFFFFF)  

</div>

## 📖 Обзор проекта
Приложение предназначено для комплексного статистического анализа текста и визуализации частотности символов. Программа предоставляет графический интерфейс для работы с текстовыми данными, вычисляя метрики структуры и популярности букв латинского алфавита.

Основные функции:
- Количественный анализ: Подсчет общего числа символов, слов и предложений в один клик.
- Частотный анализ: Определение ТОП-5 самых часто встречающихся букв латинского алфавита.
- Графическая визуализация: Построение гистограммы распределения символов от A до Z с динамическим масштабированием.
- Обработка ошибок: Валидация пустого ввода с выводом предупреждающего сообщения.

## 🛠 Технический стек
- Язык: C# (.NET 10)
- Технология: Windows Forms (WinForms)
- Графика: `System.Drawing` (использование `Graphics`, `Bitmap` и `Brushes`)

## 📂 Структура проекта блок-схемой
[![](https://mermaid.ink/img/pako:eNp9lM1u00AQx19ltcrBUdMozUeT7AEpHyA4VIrUSEhgDlt7ay-yd6P1mqaNUqntgQPc4TF6oKICRF_BfiNm7ThZqoIlOzPj3392Z2adFfakzzDBXkSTZMppoGjsCgRXEUEzJU0IrcqgufaOKBdOvVZG1q6w-Tlb6hdS_SXY1_RkIoVWMjpABM23no2AbiRoxC-YSTGWS0OWloWFPNHFhmbc06liJbdzLJSW2cap1lIAVBpWGdVWnboV3OzBSZjwmSJInrxnnm4gRtDzD0zokQoSi99_JbjmhWQi44UUgDhPv5_vKpzRgP2Derkt0GKe6PGksOypjKJFSKHORCsugpqV_Rg2xYTHpiziMddMJYB5IVVv39nYa6n8_yN7E5lCfWZW1Tr1GnK4gAZVD7uZE0hwrKlOHkumMDAuBVXnl2WskF5a0qmiZ0bKPeeM-zok5QIh40GoN45PNSVWLkg85jqmi0ddq85ws_lsdz4Jyr5kt9lDfpNfZT_AusuvS3yLVHzZaxB8BfQh-539zD9n3_MbI0H5VX6d3cJ9n3-EgMl1n92h7Jd5C-y3_BNu4EBxHxOtUtbAMVMxNS4uxudiHbKYuZiA6bNTmkbaxa5Yg2xBxRsp40qpZBqElZMuoH62-WQxOaVRYpDi3BZzwqQ3LFJgssJLTLqtw-aw1z3st9u99rDTGfQa-BygQbPb6fdaB61Bpzfo9tvrBr4oFm01B31gmM-1VEeb_wnzs_4DKedtOg?type=png)](https://mermaid.live/edit#pako:eNp9lM1u00AQx19ltcrBUdMozUeT7AEpHyA4VIrUSEhgDlt7ay-yd6P1mqaNUqntgQPc4TF6oKICRF_BfiNm7ThZqoIlOzPj3392Z2adFfakzzDBXkSTZMppoGjsCgRXEUEzJU0IrcqgufaOKBdOvVZG1q6w-Tlb6hdS_SXY1_RkIoVWMjpABM23no2AbiRoxC-YSTGWS0OWloWFPNHFhmbc06liJbdzLJSW2cap1lIAVBpWGdVWnboV3OzBSZjwmSJInrxnnm4gRtDzD0zokQoSi99_JbjmhWQi44UUgDhPv5_vKpzRgP2Derkt0GKe6PGksOypjKJFSKHORCsugpqV_Rg2xYTHpiziMddMJYB5IVVv39nYa6n8_yN7E5lCfWZW1Tr1GnK4gAZVD7uZE0hwrKlOHkumMDAuBVXnl2WskF5a0qmiZ0bKPeeM-zok5QIh40GoN45PNSVWLkg85jqmi0ddq85ws_lsdz4Jyr5kt9lDfpNfZT_AusuvS3yLVHzZaxB8BfQh-539zD9n3_MbI0H5VX6d3cJ9n3-EgMl1n92h7Jd5C-y3_BNu4EBxHxOtUtbAMVMxNS4uxudiHbKYuZiA6bNTmkbaxa5Yg2xBxRsp40qpZBqElZMuoH62-WQxOaVRYpDi3BZzwqQ3LFJgssJLTLqtw-aw1z3st9u99rDTGfQa-BygQbPb6fdaB61Bpzfo9tvrBr4oFm01B31gmM-1VEeb_wnzs_4DKedtOg)

## 🏗 Архитектура проекта
Проект разделен на логические модули для разделения интерфейса и бизнес-логики:

### ⚡ Логика анализа (TextClass.cs)
Класс содержит статические методы для обработки данных:
- `Count`: Разбивает текст по разделителям (`.`, `!`, `?` для предложений; пробельные символы (` ` `\n` `\r`) для слов) и возвращает кортеж с результатами.
- `CharStats`: Очищает текст от служебных символов и подсчитывает вхождения букв латинского алфавита `abcdefghijklmnopqrstuvwxyz`.
- `DrawStatic`: Рисует гистограмму на объекте `Bitmap`, используя максимальное значение частотности для масштабирования столбцов по высоте.

### 🖥 Логика интерфейса (TextForm.cs)
- Обработчик кнопки "Рассчитать" вызывает методы из `TextClass` для
- получения статистики и обновления полей вывода.
- В случае пустого ввода отображается предупреждающее сообщение.
- При успешном анализе вызывается метод `DrawStatic` для генерации графика, который отображается в `PictureBox` на второй вкладке.
- Результаты анализа отображаются в полях только для чтения, обеспечивая удобство и безопасность данных.
- Результаты ТОП-5 букв отображаются в виде строки, разделенной переносом строки, для наглядности.

### 🖥 Интерфейс пользователя (TextForm.Designer.cs)
Реализован с использованием `TabControl` для удобного переключения между режимами:

- Вкладка "Статистика и Анализ": Содержит многострочное поле ввода, кнопку "Рассчитать" и поля только для чтения для вывода цифр.
- Вкладка "Визуализация": Содержит PictureBox для отображения сгенерированного графика распределения букв.

## 🚀 Развертывание и использование

### 🚀 Сборка и запуск
1. Клонируйте репозиторий в какую то директорию:
	```bash
	git clone https://github.com/tstu-artemos-projects/Lab2Algos.git # или git@github.com:tstu-artemos-projects/Lab2Algos.git
	```
2. Откройте `Lab2Algos.sln` в Visual Studio.
3. Постройте и запустите проект (F5).
4. Следуйте инструкциям в интерфейсе для анализа текста и визуализации данных.

### 🚀 Скачивание исолнительного файла
Вы можете скачать готовый исполняемый файл из раздела "Releases" на GitHub
- [Releases](https://github.com/tstu-artemos-projects/Lab2Algos/releases/latest)

После скачивания распакуйте архив и запустите `Lab2Algos.exe` для использования приложения.

### 🚀 Как использовать
1. Введите или вставьте текст в главное текстовое поле на первой вкладке.
2. Нажмите кнопку "Рассчитать".
3. Ознакомьтесь с основными метриками справа от текста.
4. Перейдите на вкладку "Визуализация", чтобы увидеть график распределения букв по алфавиту.
