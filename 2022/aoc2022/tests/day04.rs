use aoc2022::{day04_part1, day04_part2};

#[test]
fn test_day04_part1_sample_input() {
    let result = day04_part1("input04_test.txt");
    assert_eq!(result.unwrap(), 2)
}

#[test]
fn test_day04_part1() {
    let result = day04_part1("input04.txt");
    assert_eq!(result.unwrap(), 487)
}

#[test]
fn test_day04_part2_sample_input() {
    let result = day04_part2("input04_test.txt");
    assert_eq!(result.unwrap(), 4)
}

#[test]
fn test_day04_part2() {
    let result = day04_part2("input04.txt");
    assert_eq!(result.unwrap(), 849)
}

