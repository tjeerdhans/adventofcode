file1 = open('./2020/input5.txt', 'r')
lines = file1.readlines()
counter = 0
max_seat_id=0

idlist = []

for l in lines:
    asbinary = l.replace('B','1').replace('F','0').replace('R','1').replace('L','0')
    row =  int(asbinary[:7],base=2)
    column = int(asbinary[7:], base=2)
    seat_id = row * 8 + column
    idlist.append(seat_id)

idlist.sort()

for id in range(128*8+8):
    if id-1 in idlist and id not in idlist and id+1 in idlist:
        print(id)
        break

