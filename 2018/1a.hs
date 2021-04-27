module Main where

-- trying this the 'naive' way, like I'm used to programming in Haskell.
main :: IO ()
main = do
    fileText <- readFile "input1.txt"
    let deltas = [dropWhile (=='+') delta | delta<-lines fileText]
    let result =  sum $ map read deltas
    print result

