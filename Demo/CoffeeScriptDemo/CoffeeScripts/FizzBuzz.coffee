# Function that calculates FizzBuzz value for given input
map =  (value) ->
	if value % 3 is 0 and value % 5 is 0
		return "FizzBuzz"
	if value % 3 is 0
		return "Fizz"
	if value % 5 is 0
		return "Buzz"
	value

console.log(map(i)) for i in [1..100]