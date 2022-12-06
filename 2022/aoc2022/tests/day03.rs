use aoc2022::{day03_part1, day03_part2};

#[test]
fn test_day03_part1_sample_input() {
    let result = day03_part1("input03_test.txt");
    assert_eq!(result.unwrap(), 157)
}

#[test]
fn test_day03_part1() {
    let result = day03_part1("input03.txt");
    assert_eq!(result.unwrap(), 7917)
}

#[test]
fn test_day03_part2_sample_input() {
    let result = day03_part2("input03_test.txt");
    assert_eq!(result.unwrap(), 70)
}

#[test]
fn test_day03_part2() {
    let result = day03_part2("input03.txt");
    assert_eq!(result.unwrap(), 2585)
}

