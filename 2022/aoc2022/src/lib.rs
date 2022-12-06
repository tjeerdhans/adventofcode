use itertools::Itertools;
use std::collections::HashMap;
use std::{collections::HashSet, error::Error, fs};

pub fn day01_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
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

pub fn day01_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
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

pub fn day02_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
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
                    _ => panic!("derp"),
                }
            }
            "Y" => {
                2 + match opponent {
                    "A" => 6,
                    "B" => 3,
                    "C" => 0,
                    _ => panic!("derp"),
                }
            }
            "Z" => {
                3 + match opponent {
                    "A" => 0,
                    "B" => 6,
                    "C" => 3,
                    _ => panic!("derp"),
                }
            }
            _ => panic!("derp"),
        };
        println!("{:?}", score);
        totalscore += score;
    }
    Ok(totalscore)
}

pub fn day02_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
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
            "X" => {
                // lose
                match opponent {
                    "A" => 3,
                    "B" => 1,
                    "C" => 2,
                    _ => panic!("derp"),
                }
            }
            "Y" => {
                // draw
                3 + match opponent {
                    "A" => 1,
                    "B" => 2,
                    "C" => 3,
                    _ => panic!("derp"),
                }
            }
            "Z" => {
                // win
                6 + match opponent {
                    "A" => 2,
                    "B" => 3,
                    "C" => 1,
                    _ => panic!("derp"),
                }
            }
            _ => panic!("derp"),
        };
        //println!("{:?}", score);
        totalscore += score;
    }
    Ok(totalscore)
}

pub fn day03_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let rucksacks: Vec<&str> = file_text.trim().lines().collect();

    let mut prio_sum = 0;
    println!("no of rucksacks: {}", rucksacks.len());
    for r in rucksacks {
        let compartment_size = r.len() / 2;
        if r.len() % 2 != 0 {
            println!("size {} in {}", compartment_size, r);
        }
        let compartment1: HashSet<char> = HashSet::from_iter(r[..compartment_size].chars());
        let compartment2: HashSet<char> = HashSet::from_iter(r[compartment_size..].chars());

        let shared_items: HashSet<_> = compartment1.intersection(&compartment2).collect();
        if shared_items.len() != 1 {
            println!(
                "{:?} in {} 1: {:?} 2: {:?}",
                shared_items, r, compartment1, compartment2
            )
        }
        for item in shared_items {
            let prio = match item.is_ascii_lowercase() {
                true => (*item as i32) % 96,
                false => 26 + ((*item as i32) % 64),
            };
            println!("{}({}):{:?}", item, *item as i32, prio);
            prio_sum += prio;
        }
    }
    println!("final: {:?}", prio_sum);
    Ok(prio_sum)
}

pub fn day03_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let rucksacks: Vec<&str> = file_text.trim().lines().collect();

    let mut prio_sum = 0;
    println!("no of rucksacks: {}", rucksacks.len());
    for set_index in 0..rucksacks.len() / 3 {
        let r1: HashSet<char> = HashSet::from_iter(rucksacks[set_index * 3].chars());
        let r2: HashSet<char> = HashSet::from_iter(rucksacks[set_index * 3 + 1].chars());
        let r3: HashSet<char> = HashSet::from_iter(rucksacks[set_index * 3 + 2].chars());
        let shared_1_2: HashSet<_> = r1.intersection(&r2).cloned().collect();
        let badge_set: HashSet<_> = shared_1_2.intersection(&r3).collect();
        if badge_set.len() != 1 {
            println!("{:?} in 1: {:?} 2: {:?} 3: {:?}", badge_set, r1, r2, r3)
        }
        for item in badge_set {
            let prio = match item.is_ascii_lowercase() {
                true => (*item as i32) % 96,
                false => 26 + ((*item as i32) % 64),
            };
            println!("{}({}):{:?}", item, *item as i32, prio);
            prio_sum += prio;
        }
    }

    println!("final: {:?}", prio_sum);
    Ok(prio_sum)
}

pub fn day04_part1(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let pairs: Vec<&str> = file_text.trim().lines().collect();
    let mut count = 0;
    for pair in pairs {
        let assignments = pair.split(',').collect::<Vec<&str>>();
        let first: Vec<u8> = assignments[0]
            .split('-')
            .map(|i| i.parse::<u8>().unwrap())
            .collect();
        let second: Vec<u8> = assignments[1]
            .split('-')
            .map(|i| i.parse::<u8>().unwrap())
            .collect();

        if (first[0] <= second[0] && first[1] >= second[1])
            || (first[0] >= second[0] && first[1] <= second[1])
        {
            count += 1;
        }
    }

    Ok(count)
}

pub fn day04_part2(file_path: &str) -> Result<i32, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let pairs: Vec<&str> = file_text.trim().lines().collect();
    let mut count = 0;
    for pair in pairs {
        let assignments = pair.split(',').collect::<Vec<&str>>();
        let first: Vec<u8> = assignments[0]
            .split('-')
            .map(|i| i.parse::<u8>().unwrap())
            .collect();
        let second: Vec<u8> = assignments[1]
            .split('-')
            .map(|i| i.parse::<u8>().unwrap())
            .collect();

        // easier to check for no overlap (to me, in any case)
        if !(first[1] < second[0] || second[1] < first[0]) {
            count += 1;
        }
    }

    Ok(count)
}

pub fn day05_part1(file_path: &str) -> Result<String, Box<dyn Error>> {
    let file_text = fs::read_to_string(file_path)?;
    let lines = file_text.trim().lines().collect::<Vec<&str>>();
    // get number of stacks
    let stack_line = lines.iter().find(|l| l.starts_with(' ')).unwrap();
    let stack_count = (stack_line.len() - 2) / 4;
    let mut stacks: HashMap<usize, Vec<char>> = HashMap::new();

    // build the stacks
    for line in lines
        .iter()
        .take_while(|l| !l.starts_with(' '))
        .cloned()
        .collect::<Vec<&str>>()
    {
        for stack_index in 0..stack_count {
            let c = line.as_bytes()[(stack_index * 4) + 1] as char;
            if !c.is_ascii_whitespace() {
                stacks.entry(stack_index).or_default().insert(0, c);
            }
        }
    }

    // move stuff around
    for line in lines
        .iter()
        .skip_while(|l| !l.starts_with(' '))
        .skip(2)
        .cloned()
        .collect::<Vec<&str>>()
    {
        // split by " from "
        let segments = line.split(" from ").collect::<Vec<&str>>();
        let amount = segments[0].split_whitespace().collect::<Vec<&str>>()[1].parse::<i32>()?;
        // split by " to "
        let from_to = segments[1].split(" to ").collect::<Vec<&str>>();
        let from = from_to[0].parse::<usize>()? - 1;
        let to = from_to[1].parse::<usize>()? - 1;

        for _ in 0..amount {
            let c = stacks.entry(from).or_default().pop().unwrap();
            stacks.entry(to).or_default().push(c);
        }
    }

    // get the top crates on the stacks
    let result = stacks
        .iter()
        .map(|(_, stack)| stack.last().unwrap().clone())
        .collect::<String>();
    Ok(result)
}

pub fn day05_part2(file_path: &str) -> Result<String, Box<dyn Error>> {
    Ok("Derp".to_string())
}
