use aoc2022::{day_02_part1, day_02_part2};

#[test]
fn test_day02_part1_sample_input() {
    let result = day_02_part1("input02_test.txt");
    assert_eq!(result.unwrap(), 15)
}

#[test]
fn test_day02_part1() {
    let result = day_02_part1("input02.txt");
    assert_eq!(result.unwrap(), 15691)
}

#[test]
fn test_day02_part2_sample_input() {
    let result = day_02_part2("input02_test.txt");
    assert_eq!(result.unwrap(), 12)
}

#[test]
fn test_day02_part2() {
    let result = day_02_part2("input02.txt");
    assert_eq!(result.unwrap(), 12989)
}

