module Aoc2018_2a where
 
import Data.List

main :: IO ()
main = do
    fileText <- readFile "input2.txt"
    let ids = map sort $ lines fileText
    print ids

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

countOccurs :: Int -> Parser Int 
countOccurs n = Parser f
    where
        f [] = Nothing 
        f xs = 

