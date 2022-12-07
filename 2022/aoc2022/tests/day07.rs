use aoc2022::{day07_part1, day07_part2};

#[test]
fn test_day07_part1_sample_input() {
    let result = day07_part1("input07_test.txt");
    assert_eq!(result.unwrap(), 7)
}

#[test]
fn test_day07_part1() {
    let result = day07_part1("input07.txt");
    assert_eq!(result.unwrap(), 1779)
}

#[test]
fn test_day07_part2_sample_input() {
    let result = day07_part2("input07_test.txt");
    assert_eq!(result.unwrap(), 19)
}

#[test]
fn test_day07_part2() {
    let result = day07_part2("input07.txt");
    assert_eq!(result.unwrap(), 2635)
}

