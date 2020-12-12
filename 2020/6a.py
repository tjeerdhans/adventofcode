file1 = open('./2020/input6.txt', 'r')
filetext = file1.read()
groups = filetext.split("\n\n")

counter=0

for g in groups:
    g=g.replace('\n','')
    counter += len(set(g))
    # unique = []
    # [unique.append(x) for x in g if x not in unique]
    # counter += len(unique)

print(counter)

