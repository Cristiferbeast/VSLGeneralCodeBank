extends Node

var variable1 :String = ""
var variable2 :String = ""
var results_var :String = ""

func handle_event(event_data, dialog_node):
	#""" 
		#If this event should wait for dialog advance to occur, uncomment the WAITING line
		#If this event should block the dialog from continuing, uncomment the WAITINT_INPUT line
		#While other states exist, they generally are not neccesary, but include IDLE, TYPING, and ANIMATING
	#"""
	dialog_node.set_state(dialog_node.state.WAITING)
	dialog_node.set_state(dialog_node.state.WAITING_INPUT)
	
	#Get the current values of the "variable1" and "variable2" variables
	var variable1_value = Dialogic.get_variable(variable1)
	var variable2_value = Dialogic.get_variable(variable2)
	var results_var_value = Dialogic.get_variable(results_var)
	
	# Compare the values and set the "result" variable accordingly
	if variable1_value == variable2_value:
		Dialogic.set_variable(results_var_value, "equal")
	elif variable1_value < variable2_value:
		Dialogic.set_variable(results_var_value, "less than")
	else:
		Dialogic.set_variable(results_var_value, "greater than")
	
	# once you want to continue with the next event
	dialog_node._load_next_event()
	dialog_node.set_state(dialog_node.state.READY) 
