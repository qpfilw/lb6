open System

module CalculatorFunctions =

    let add x y = x + y

    let subtract x y = x - y

    let multiply x y = x * y

    let divide x y =
        if y = 0.0 then None
        else Some (x / y)

    let power baseValue exponent =
        Math.Pow(baseValue, exponent)

    let sqrt x =
        if x < 0.0 then None
        else Some (Math.Sqrt x)

    let applyTrigFunction trigFunc angleInDegrees =
        let radians = angleInDegrees * Math.PI / 180.0
        trigFunc radians
    let sinDeg = applyTrigFunction Math.Sin
    let cosDeg = applyTrigFunction Math.Cos
    let tanDeg = applyTrigFunction Math.Tan

module Calculator =

    open CalculatorFunctions
    let rec readNumber prompt =
        printf "%s" prompt
        match System.Double.TryParse(Console.ReadLine()) with
        | (true, value) -> value
        | _ ->
            printfn "Ошибка ввода. Попробуйте снова."
            readNumber prompt

    let printResult optionalResult =
        match optionalResult with
        | Some value -> printfn "Результат: %f" value
        | None       -> printfn "Ошибка: деление на ноль или некорректный ввод."

    let rec mainLoop () =
        printfn "         Калькулятор             "
        printfn "Выберите операцию:"
        printfn "1 - Сложение"
        printfn "2 - Вычитание"
        printfn "3 - Умножение"
        printfn "4 - Деление"
        printfn "5 - Возведение в степень"
        printfn "6 - Квадратный корень"
        printfn "7 - Синус (в градусах)"
        printfn "8 - Косинус (в градусах)"
        printfn "9 - Тангенс (в градусах)"
        printfn "0 - Выход из программы"

        printf "Введите номер операции: "
        let input = Console.ReadLine()
        match input with
        | "1" ->
            let x = readNumber "Введите первое число: "
            let y = readNumber "Введите второе число: "
            let result = add x y
            printfn "Результат: %f" result
            continueLoop ()
        | "2" ->
            let x = readNumber "Введите первое число: "
            let y = readNumber "Введите второе число: "
            let result = subtract x y
            printfn "Результат: %f" result
            continueLoop ()
        | "3" ->
            let x = readNumber "Введите первое число: "
            let y = readNumber "Введите второе число: "
            let result = multiply x y
            printfn "Результат: %f" result
            continueLoop ()
        | "4" ->
            let x = readNumber "Введите делимое: "
            let y = readNumber "Введите делитель: "
            let result = divide x y
            printResult result
            continueLoop ()
        | "5" ->
            let x = readNumber "Введите основание степени: "
            let y = readNumber "Введите показатель степени: "
            let result = power x y
            printfn "Результат: %f" result
            continueLoop ()
        | "6" ->
            let x = readNumber "Введите число для извлечения квадратного корня: "
            let result = sqrt x
            printResult result
            continueLoop ()
        | "7" ->
            let angle = readNumber "Введите угол (в градусах): "
            let result = sinDeg angle
            printfn "sin(%f) = %f" angle result
            continueLoop ()
        | "8" ->
            let angle = readNumber "Введите угол (в градусах): "
            let result = cosDeg angle
            printfn "cos(%f) = %f" angle result
            continueLoop ()
        | "9" ->
            let angle = readNumber "Введите угол (в градусах): "
            let result = tanDeg angle
            printfn "tan(%f) = %f" angle result
            continueLoop ()
        | "0" ->
            printfn "Выход из программы..."
        | _ ->
            printfn "Неизвестная операция. Попробуйте снова."
            continueLoop ()

    and continueLoop () =
        printfn ""
        printf "Нажмите Enter, чтобы продолжить, или 0 — для выхода: "
        let choice = Console.ReadLine()
        if choice = "0" then
            printfn "Выход из программы..."
        else
            mainLoop ()

let main _ =
    Calculator.mainLoop ()
    0
main ()

