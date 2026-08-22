import sys


# =============================================================================
# TRIANGLE GENERATOR  (original: triangle.py)
# Integration change: sys.exit(1) replaced with return
# =============================================================================
def generate_triangle():
    print("=== Triangle Generator ===")

    try:
        user_input = input(
            "Enter the height of the triangle (1-20): "
        ).strip()

        if not user_input:
            print("Error: Input cannot be empty.")
            return

        height = int(user_input)

        if height < 1 or height > 20:
            print("Error: Height must be between 1 and 20.")
            return

    except ValueError:
        print("Error: Invalid input. Please enter a whole number.")
        return

    for row in range(1, height + 1):
        for col in range(1, row + 1):
            print("*", end="")
        print()


# =============================================================================
# RECTANGLE GENERATOR  (original: rectangle.py — Abeer Al Hassan, TP108997)
# Integration change: main() renamed to rectangle_program()
# =============================================================================
def get_integer(prompt, min_val, max_val):
    raw = input(prompt)
    try:
        value = int(raw)
    except ValueError:
        raise ValueError(
            f"Error: invalid number. "
            f"Width must be 1-40, height 1-20."
        )
    if value < min_val or value > max_val:
        raise ValueError(
            f"Error: invalid number. "
            f"Width must be 1-40, height 1-20."
        )
    return value


def rect_filled(width, height):
    for row in range(height):
        for col in range(width):
            print('*', end='')
        print()


def rect_outline(width, height):
    for row in range(height):
        if row == 0 or row == height - 1:
            for col in range(width):
                print('*', end='')
        else:
            print('*', end='')
            print(' ' * (width - 2), end='')
            print('*', end='')
        print()


def rectangle_program():
    try:
        width = get_integer("Enter rectangle width  (1-40): ", 1, 40)
    except ValueError as e:
        print(e)
        return

    try:
        height = get_integer("Enter rectangle height (1-20): ", 1, 20)
    except ValueError as e:
        print(e)
        return

    fill = input("Fill style - (f)illed or (o)utlined: ")
    if fill.startswith('o'):
        rect_outline(width, height)
    else:
        rect_filled(width, height)


# =============================================================================
# SQUARE GENERATOR  (original: ICS.py)
# Integration change: flat script wrapped in square_program()
# =============================================================================
def square_program():
    size = int(input("Enter square size (1-9): "))

    print("Choose symbol:")
    print("1. *")
    print("2. #")
    print("3. @")

    choice = input("Enter choice: ")

    if choice == "1":
        symbol = "*"
    elif choice == "2":
        symbol = "#"
    else:
        symbol = "@"

    print("1. Filled Square")
    print("2. Hollow Square")

    shape = input("Enter choice: ")

    if shape == "1":
        for i in range(size):
            print(symbol * size)
    else:
        for i in range(size):
            if i == 0 or i == size - 1:
                print(symbol * size)
            else:
                print(symbol + " " * (size - 2) + symbol)


# =============================================================================
# DIAMOND GENERATOR  (original: diamond.py)
# Integration change: sys.exit(1) replaced with return
# =============================================================================
def generate_diamond():
    print("=== Diamond Generator ===")

    try:
        user_input = input(
            "Enter the odd height of the diamond (3-19): "
        ).strip()

        if not user_input:
            print("Error: Input cannot be empty.")
            return

        height = int(user_input)

        if height < 3 or height > 19:
            print("Error: Height must be between 3 and 19.")
            return

        if height % 2 == 0:
            print("Error: Height must be an ODD number.")
            return

    except ValueError:
        print("Error: Invalid input. Please enter a whole number.")
        return

    n = (height + 1) // 2

    for i in range(1, n + 1):
        spaces = " " * (n - i)
        stars = "*" * (2 * i - 1)
        print(spaces + stars)

    for i in range(n - 1, 0, -1):
        spaces = " " * (n - i)
        stars = "*" * (2 * i - 1)
        print(spaces + stars)


# =============================================================================
# MAIN MENU
# =============================================================================
def main():
    while True:
        print("\n================================")
        print("    SHAPE GENERATION SYSTEM     ")
        print("================================")
        print("1. Triangle Generator")
        print("2. Rectangle Generator")
        print("3. Square Generator")
        print("4. Diamond Generator")
        print("5. Exit")
        print("--------------------------------")

        choice = input("Enter your choice: ").strip()

        if choice == '1':
            generate_triangle()
        elif choice == '2':
            rectangle_program()
        elif choice == '3':
            square_program()
        elif choice == '4':
            generate_diamond()
        elif choice == '5':
            sys.exit(0)
        else:
            print("Invalid choice! Please enter 1-5.")


if __name__ == "__main__":
    main()
