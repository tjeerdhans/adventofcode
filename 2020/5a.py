file1 = open('./2020/input5.txt', 'r')
lines = file1.readlines()
counter = 0
max_seat_id=0

# test = 'FBFBBFFRLR'
# asbinary = test.replace('B','1').replace('F','0').replace('R','1').replace('L','0')
# row =  int(asbinary[:7],base=2)
# print(asbinary)
# print(asbinary[:7])
# print(asbinary[7:])
# print(row)
# column = int(asbinary[7:], base=2)
# seat_id = row * 8 + column
# print(seat_id)

for l in lines:
    asbinary = l.replace('B','1').replace('F','0').replace('R','1').replace('L','0')
    row =  int(asbinary[:7],base=2)
    column = int(asbinary[7:], base=2)
    seat_id = row * 8 + column
    idlist.append(seat_id)
    if seat_id > max_seat_id:
        max_seat_id=seat_id

print(max_seat_id)
