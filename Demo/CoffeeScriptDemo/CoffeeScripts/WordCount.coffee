#writes a class that counts words
word_counter =
	count : (input) -> #function with 1 argument
		trimmed = input.trim() #trim the space
		tokens = trimmed.split(/[a-zA-Z_0-9-']+/) #split the array 
		words = (word for word in tokens when word isnt "") #to remove empty string from tokens array
		console.log JSON.stringify words #Debug line
		words.length #returns length of array

console.log word_counter.count "Once-upon@#, a's time."


