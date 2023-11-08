# Core Requirements
try:
    # Ask the user for their grade percentage
    percentage = float(input("Enter your grade percentage: "))
    
    # Initialize variables to store the letter grade and pass/fail message
    letter = ""
    pass_message = ""

    # Determine the letter grade
    if percentage >= 90:
        letter = "A"
    elif percentage >= 80:
        letter = "B"
    elif percentage >= 70:
        letter = "C"
    elif percentage >= 60:
        letter = "D"
    else:
        letter = "F"

    # Check if the user passed the course
    if percentage >= 70:
        pass_message = "Congratulations! You passed the course."
    else:
        pass_message = "You didn't pass this time. Keep working for next time."

    # Display the letter grade and pass/fail message
    print(f"Your letter grade is: {letter}")
    print(pass_message)

    # Stretch Challenge
    if letter in ("A", "B", "C", "D") and percentage % 10 >= 7:
        sign = "+"
    elif letter in ("A", "B", "C", "D") and percentage % 10 < 3:
        sign = "-"
    else:
        sign = ""

    # Display the letter grade with the sign (if applicable)
    if sign:
        print(f"Your letter grade with sign is: {letter}{sign}")

except ValueError:
    print("Invalid input. Please enter a valid percentage.")
