@echo off
set /p path="Введите путь к папке для очистки: "

if not exist "%path%" (
    echo Ошибка: Путь '%path%' не существует!
    pause
    exit /b
)

echo Поиск папок bin и obj в: %path%
for /d /r "%path%" %%d in (bin,obj) do (
    if exist "%%d" (
        echo Удаляю: %%d
        rmdir /s /q "%%d"
    )
)

echo Готово!
pause