use_bpm 60

# Define the function y
define :y do |x|
  # Calculate the value of y based on a equation
  linear(x,m,b)

  lowest_note = :C4
  highest_note = :C6

  if y_value = 0
    #play catnoise
    puts "0 reached at {x}"
    return
  end

  # Adjust y_value to fall within the comfortable note range
  adjusted_y_value = y_value + note_to_midi(lowest_note)

  # Check for comfortable y_value and play nothing
  return if adjusted_y_value < note_to_midi(lowest_note)
  return if adjusted_y_value > note_to_midi(highest_note)

  play midi_to_note(adjusted_y_value)
end


#Simple Functions
define :linear do |x,m,b|
  y_value = (m * x) + b
end

define :square do |x, a, m, b|
  #slope intercept
  y_value = (a*(x*x))+(m*x)+b
end

define :square do |a, b, x, c, d|
  #input as factored
  y_value = (a*c)(x*x) + (b*c*x) + (d*a*x) + (b*d)
end

define :square do |c, m, x, d, b|
  #vertex
  y_value = (m * (x-d)) + b + c
end

define :absolute do |x, m, b|
  if x > 0
    x = x * -1
  end
  y_value = (m*x)+b
end

define :quadratic do |a,b,c,x|
  y_valuea = (-b + sqrt(b^2 + 4*(a*c)))/2a
  y_valueb = (-b - sqrt(b^2 + 4*(a*c)))/2a

  #convert to factored form
  y_valuea *= -1
  y_valueb *= -1

  square(1,y_valuea,x,1,y_valueb)
end

define: perpendicular do |m , y, b|
  #y = -1/m x + b
  y_value = -(1/m) + b
end

define: perpendicular do |x,m,c,b,y|
  #y-a = -1/m (x - c) + b
  y_value = (-(1/m)*(x-c))+b + y
end

define: inverse do |x,b,m|
  # y = mx + b
  # x = my + b
  # my = x - b
  y_value = (x-b)/m
end

define: mixtures do |c, iv, ca, v|
  dc = ((c*iv) + (ca *v)) / (iv + v)
  # iv = (conc + (ca * v))/dc - v
  # v = ((c * iv) + conc))/dc - iv
  # c = (dc(iv+v)-(ca*v))/iv
  # ca = (dc(iv+v)-(c*iv))/v
end

#function incrementer
in_thread do
  x = 0
  loop do
    y(x)
    sleep 1
    x = x + 1
  end
end
