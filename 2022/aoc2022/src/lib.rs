use itertools::Itertools;
use std::{error::Error, fs, collections::HashSet};

pub fn day_01_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let elves = file_text.split("\n\n");
    let result: i32 = elves
        .map(|e| {
            e.split_whitespace()
                .map(|c| c.parse::<i32>().unwrap())
                .sum()
        })
        .max()
        .unwrap();
    Ok(result)
}

pub fn day_01_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let elves = file_text.split("\n\n");
    let result = elves
        .map(|e| {
            e.split_whitespace()
                .map(|c| c.parse::<i32>().unwrap())
                .sum::<i32>()
        })
        .sorted()
        .rev()
        .take(3)
        .sum();
    Ok(result)
}

pub fn day_02_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let rounds = file_text.trim().lines();
    let mut totalscore = 0;
    for round in rounds {
        let moves = round.split_whitespace().collect::<Vec<&str>>();
        let opponent = moves[0];
        let me = moves[1];
        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.
        // A rock B paper C scissors
        // X      Y       Z
        let score = match me {
            "X" => {
                1 + match opponent {
                    "A" => 3,
                    "B" => 0,
                    "C" => 6,
                    _ => panic!("derp")
                }
            }
            "Y" => {
                2 + match opponent {
                    "A" => 6,
                    "B" => 3,
                    "C" => 0,
                    _ => panic!("derp")
                }
            }
            "Z" => {
                3 + match opponent {
                    "A" => 0,
                    "B" => 6,
                    "C" => 3,
                    _ => panic!("derp")
                }
            },
            _ => panic!("derp")
        };
        println!("{:?}", score);
        totalscore += score;
    }
    Ok(totalscore)
}

pub fn day_02_part2(file_path: &str) -> Result<i32, Box<dyn Error>>{
    let file_text = fs::read_to_string(file_path)?;
    let rounds = file_text.trim().lines();
    let mut totalscore = 0;
    for round in rounds {
        let moves = round.split_whitespace().collect::<Vec<&str>>();
        let opponent = moves[0];
        let me = moves[1];
        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.
        // A rock 1 - B paper 2 - C scissors 3
        // X lose     Y draw      Z win
        let score = match me {
            "X" => { // lose
                match opponent {
                    "A" => 3,
                    "B" => 1,
                    "C" => 2,
                    _ => panic!("derp")
                }
            }
            "Y" => { // draw
                3 + match opponent {
                    "A" => 1,
                    "B" => 2,
                    "C" => 3,
                    _ => panic!("derp")
                }
            }
            "Z" => { // win
                6 + match opponent {
                    "A" => 2,
                    "B" => 3,
                    "C" => 1,
                    _ => panic!("derp")
                }
            },
            _ => panic!("derp")
        };
        //println!("{:?}", score);
        totalscore += score;
    }
    Ok(totalscore)
}


pub fn day_03_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let rucksacks: Vec<&str> = file_text.trim().lines().collect();

    for r in rucksacks {
        let compartment_size = r.len()/2;
        let compartment1: HashSet<char> = HashSet::from_iter(r[..compartment_size].chars());
        let compartment2: HashSet<char> = HashSet::from_iter(r[compartment_size+1..].chars());    

        let shared_item = compartment1.intersection(&compartment2).collect::<HashSet<&char>>().iter();


    }

    Ok(1)
}