use aoc2022::{day06_part1, day06_part2};

#[test]
fn test_day06_part1_sample_input() {
    let result = day06_part1("input06_test.txt");
    assert_eq!(result.unwrap(), 7)
}

#[test]
fn test_day06_part1() {
    let result = day06_part1("input06.txt");
    assert_eq!(result.unwrap(), 1779)
}

#[test]
fn test_day06_part2_sample_input() {
    let result = day06_part2("input06_test.txt");
    assert_eq!(result.unwrap(), 19)
}

#[test]
fn test_day06_part2() {
    let result = day06_part2("input06.txt");
    assert_eq!(result.unwrap(), 2635)
}

