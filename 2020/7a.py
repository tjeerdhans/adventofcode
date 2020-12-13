file1 = open('./2020/input7.txt', 'r')
rules = file1.read().split('\n')
count = 0

gold_rules = [rule for rule in rules if ' shiny gold' in rule]
gold_bags = [' '.join(r.split(' ')[:2]) for r in gold_rules]
rest_rules = [rule for rule in rules if rule not in gold_rules]

count += len(gold_bags)

def get_bags(rule):
    r = rule[:-1] # remove trailing stop
    words = r.split(' ')
    bags = []
    if words[4] == 'no': # no other bags
        return []
    while len(words)>4:
        words = words[4:]
        bags.append(' '.join(words[1:3]))
    return bags

def check_bag(bag):
    if bag in scum_bags:
        return False
    if bag in gold_bags:
        return True
    #bag_rule = list(filter(lambda x: x.startswith(bag), rest_rules))
    bag_rule = [r for r in rest_rules if r.startswith(bag)]
    if len(bag_rule) > 1:
        print(bag_rule)
    bag_rule = bag_rule[0]
    bags = get_bags(bag_rule)
    win = any([check_bag(b) for b in bags])
    if not win:
        scum_bags.append(bag)
    return win

scum_bags = []
for r in rest_rules:
    bags = get_bags(r)
    win = False
    for b in bags:
        if check_bag(b):
            win = True
            break
    if win:
        count+=1


print(count)