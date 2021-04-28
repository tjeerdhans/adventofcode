module Aoc2018_2a where

import Data.List
import Data.Maybe

main :: IO ()
main = do
    fileText <- readFile "input2.txt"
    let ids = lines fileText
    let checksum2 = sum [fst $ fromJust parsed| id<-ids, let parsed = runParser (hasExactOccurs 2) id, isJust parsed ]
    let checksum3 = sum [fst $ fromJust parsed| id<-ids, let parsed = runParser (hasExactOccurs 3) id, isJust parsed ]
    print $ checksum2 * checksum3

newtype Parser a = Parser {runParser :: String -> Maybe (a, String)}
first :: (a -> b) -> (a, c) -> (b, c)
first f (a, c) = (f a, c)

instance Functor Parser where
  fmap f pa = Parser $ fmap (first f) . runParser pa

instance Applicative Parser where
  -- pure :: a -> Parser a
  pure x = Parser (\s -> Just (x, s))
  -- (<*>) :: Parser (a -> b) -> Parser a -> Parser b
  p1 <*> p2 = Parser $ \s -> case runParser p1 s of
    Nothing -> Nothing
    Just (f, rest) -> runParser (fmap f p2) rest

-- Parser for a String that checks if the string has a character that occurs exactly n times.
hasExactOccurs :: Int -> Parser Int
hasExactOccurs n = Parser f
    where
        f [] = Nothing
        f xs =  if any (\x -> length x == n) $ group $ sort xs then Just (1, xs) else Just (0, xs)

--checksum :: Parser Int
--checksum = (*) <$> hasExactOccurs 2 <*> hasExactOccurs 3

