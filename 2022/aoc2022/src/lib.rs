use std::{error::Error, fs};
use itertools::Itertools;

pub fn day_01_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let elves = file_text.split("\n\n");
    let result: i32 = elves
        .map(|e| e.split_whitespace().map(|c| c.parse::<i32>().unwrap()).sum())
        .max().unwrap();
    Ok(result)
}

pub fn day_01_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let elves = file_text.split("\n\n");
    let result = elves
        .map(|e| e.split_whitespace().map(|c| c.parse::<i32>().unwrap()).sum::<i32>())
        .sorted().rev().take(3).sum();
    Ok(result)
}
