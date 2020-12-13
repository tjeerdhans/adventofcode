file1 = open('./2020/input7.txt', 'r')
rules = file1.read().split('\n')

def get_bags(rule):
    r = rule[:-1] # remove trailing stop
    words = r.split(' ')
    bags = []
    if words[4] == 'no':
        return []
    while len(words)>4:
        words = words[4:]
        bags.append((int(words[0]), ' '.join(words[1:3])))
    return bags

def count_bags(bag):
    bag_rule = [r for r in rules if r.startswith(bag[1])][0]
    bags = get_bags(bag_rule)
    if len(bags)==0:
        return bag[0]
    total = bag[0] + bag[0] * sum([count_bags(b) for b in bags])
    return total

result = count_bags((1,'shiny gold')) - 1

print(result)