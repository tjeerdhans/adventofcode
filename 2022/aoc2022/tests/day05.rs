use aoc2022::{day05_part1, day05_part2};

#[test]
fn test_day05_part1_sample_input() {
    let result = day05_part1("input05_test.txt");
    assert_eq!(result.unwrap(), 2)
}

#[test]
fn test_day05_part1() {
    let result = day05_part1("input05.txt");
    assert_eq!(result.unwrap(), 487)
}

#[test]
fn test_day05_part2_sample_input() {
    let result = day05_part2("input05_test.txt");
    assert_eq!(result.unwrap(), 4)
}

#[test]
fn test_day05_part2() {
    let result = day05_part2("input05.txt");
    assert_eq!(result.unwrap(), 849)
}

