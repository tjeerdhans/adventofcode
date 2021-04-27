module Main where

main :: IO ()
main = do
    fileText <- readFile "input1.txt"
    let freqChanges = getFreqChanges fileText
    let freqs = getFreqs (cycle' 150 freqChanges)
    let firstDup = fstDup freqs
    print firstDup

getFreqChanges :: String -> [Int]
getFreqChanges fileText = map read $ [dropWhile (=='+') delta | delta <- lines fileText]

getFreqs :: [Int] -> [Int]
getFreqs = scanl (+) 0

cycle' :: Int -> [a] -> [a]
cycle' n xs = take (n * length xs) $ cycle xs

getDups :: [Int] -> [Int]
getDups [] = []
getDups (x:xs) = if x `elem` xs
        then x : getDups (take (head pos2) xs)
        else getDups xs
        where pos2 = findPos x xs

fstDup :: [Int] -> Int
fstDup = last . getDups

findPos :: Eq a => a -> [a] -> [Int]
findPos x ys = [i | (i,y) <- zip [0..] ys, y == x]

testList1 = getFreqs (cycle' 100 [3, 3, 4, -2, -4])
testList2 = getFreqs (cycle' 100 [-6, 3, 8, 5, -6])
testList3 = getFreqs (cycle' 100 [7, 7, -2, -7, -4])

