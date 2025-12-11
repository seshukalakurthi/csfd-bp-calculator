Feature: BMI classification
  The calculator should classify BMI correctly
  based on height and weight inputs

  Scenario: Normal BMI
    Given a height of 170 cm
    And a weight of 65 kg
    When I calculate the BMI
    Then the BMI value should be 22.5
    And the BMI category should be "Normal"

  Scenario: Underweight BMI
    Given a height of 180 cm
    And a weight of 55 kg
    When I calculate the BMI
    Then the BMI category should be "Underweight"

  Scenario: Obese BMI
    Given a height of 160 cm
    And a weight of 95 kg
    When I calculate the BMI
    Then the BMI category should be "Obese"
