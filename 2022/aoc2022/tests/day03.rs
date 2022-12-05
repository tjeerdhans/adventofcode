use aoc2022::{day_03_part1, day_03_part2};

#[test]
fn test_day03_part1_sample_input() {
    let result = day_02_part1("input03_test.txt");
    assert_eq!(result.unwrap(), 15)
}

#[test]
fn test_day03_part1() {
    let result = day_02_part1("input03.txt");
    assert_eq!(result.unwrap(), 15691)
}

#[test]
fn test_day03_part2_sample_input() {
    let result = day_02_part2("input03_test.txt");
    assert_eq!(result.unwrap(), 12)
}

#[test]
fn test_day03_part2() {
    let result = day_02_part2("input03.txt");
    assert_eq!(result.unwrap(), 12989)
}

