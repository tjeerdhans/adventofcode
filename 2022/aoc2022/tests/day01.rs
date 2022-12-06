use aoc2022::{day01_part1, day01_part2};

#[test]
fn test_day01_part1_sample_input() {
    let result = day01_part1("input01_test.txt");
    assert_eq!(result.unwrap(), 24000)
}

#[test]
fn test_day01_part1() {
    let result = day01_part1("input01.txt");
    assert_eq!(result.unwrap(), 70720)
}

#[test]
fn test_day01_part2_sample_input() {
    let result = day01_part2("input01_test.txt");
    assert_eq!(result.unwrap(), 45000)
}

#[test]
fn test_day01_part2() {
    let result = day01_part2("input01.txt");
    assert_eq!(result.unwrap(), 207148)
}