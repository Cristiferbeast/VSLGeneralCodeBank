tool
extends "res://addons/dialogic/Editor/Events/Parts/EventPart.gd"

# has an event_data variable that stores the current data!!!

## node references
onready var a_variable_field = $Properties/Variable1
onready var b_variable_field = $Properties/Variable2
onready var out_variable_field = $Properties/Variable3


# used to connect the signals
func _ready():
	a_variable_field.connect("text_entered", self, "_on_text_changed", ['aVariable'])
	b_variable_field.connect("text_entered", self, "_on_text_changed", ['bVariable'])
	out_variable_field.connect("text_entered", self, "_on_text_changed", ['outVariable'])
	

# called by the event block
func load_data(data:Dictionary):
	# First set the event_data
	.load_data(data)
	
	# Now update the ui nodes to display the data. 
	a_variable_field.text = event_data['aVariable']
	b_variable_field.text = event_data['bVariable']
	out_variable_field.text = event_data['outVariable']


# called when any of the text fields are changed
func _on_text_changed(new_text: String, data_key: String):
	event_data[data_key] = new_text
		
	# informs the parent about the changes!
	data_changed()


 # has to return the wanted preview, only useful for body parts
func get_preview():
	return ''

 ## EXAMPLE CHANGE IN ONE OF THE NODES
func _on_InputField_text_changed(text):
	event_data['my_text_key'] = text
	
	# informs the parent about the changes!
	data_changed()
