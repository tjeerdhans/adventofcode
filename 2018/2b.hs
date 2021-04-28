module Aoc2018_2b where

import Data.List ( sort, intersect )

--2b
-- pair programmed with Roland P.
-- use Levenshtein distance? This might be too slow, we only need to check
-- for distances greater than 1

-- return true if string difference is 1 pos (levenshtein == 1), else false
-- assuming strings of equal size
stringdif1 :: Int -> String -> String -> Bool
stringdif1 1 [] [] = True
stringdif1 _ [] [] = False
stringdif1 0 (x:xs) (y:ys)
    | x /= y = stringdif1 1 xs ys
    | otherwise = stringdif1 0 xs ys
stringdif1 1 (x:xs) (y:ys)
    | x /= y = False
    | otherwise = stringdif1 1 xs ys

-- not used, used `intersect` instead.
commonChars :: String -> String -> String
commonChars _ [] = []
commonChars [] _ = []
commonChars (x:xs) (y:ys) = if x==y then x:commonChars xs ys else commonChars xs ys

-- Get the unique chars of the correct box id, leaving out the common chars.
-- this assumes a sorted list
getCorrectIdSetChars :: [String] -> Maybe String
getCorrectIdSetChars [] = Nothing
getCorrectIdSetChars (x:y:ys) = if stringdif1 0 x y then Just (x `intersect` y) else getCorrectIdSetChars (y:ys)

main :: IO ()
main = do
    fileText <- readFile "input2.txt"
    let ids = lines fileText
    let chars = getCorrectIdSetChars $ sort ids
    print chars

