func CheckDifference(variable1, variable2, result_var):
	# Get the current values of the "variable1" and "variable2" variables
	var variable1_value = Dialogic.get_variable(variable1)
	var variable2_value = Dialogic.get_variable(variable2)
	
	# Compare the values and set the "result" variable accordingly
	if variable1_value == variable2_value:
		Dialogic.set_variable(result_var, "equal")
	elif variable1_value < variable2_value:
		Dialogic.set_variable(result_var, "less than")
	else:
		Dialogic.set_variable(result_var, "greater than")


