file1 = open('./2020/input6.txt', 'r')
filetext = file1.read()
groups = filetext.split("\n\n")

counter=0

for g in groups:
    members = g.split('\n')
    #sets = [set(x) for x in members]
    intersection= set(members[0]).intersection(*members)
    counter += len(intersection)

print(counter)

