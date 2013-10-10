# Class that calculates FizzBuzz value for given input
class Value
	constructor : (@number) ->

	map : ->
		if @_is_fizzbuzz()
			return "FizzBuzz"
		if @_is_fizz()
			return "Fizz"
		if @_is_buzz()
			return "Buzz"
		@number

	_is_fizz: ->
		@number % 3 is 0

	_is_buzz: ->
		@number % 5 is 0

	_is_fizzbuzz: ->
		@_is_fizz() and @_is_buzz()
		

console.log(new Value(i).map()) for i in [1..100]