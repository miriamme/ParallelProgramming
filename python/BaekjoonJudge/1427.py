# 문제
# 배열을 정렬하는 것은 쉽다. 수가 주어지면, 그 수의 각 자리수를 내림차순으로 정렬해보자.

# 입력
# 첫째 줄에 정렬하고자하는 수 N이 주어진다. N은 1,000,000,000보다 작거나 같은 자연수이다.

# 출력
# 첫째 줄에 자리수를 내림차순으로 정렬한 수를 출력한다.

# 예제
# 입력
# 2143
# 출력
# 4321

input = input()
LIMIT_NUMBER = 1000000000 
try:
    temp =  int(input)
    if temp > LIMIT_NUMBER:
        raise ValueError('1,000,000,000보다 작거나 같은 자연수이어야 합니다.')

    num_list = list(input)
    num_list.sort()
    num_list.reverse()
    print(''.join(num_list))
except Exception as inst:
    print('Exception : ',inst)