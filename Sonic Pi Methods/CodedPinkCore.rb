#Pinkcore Example in Pi

use_bpm 100 #Change this for either Fast or Slow Pink Core

#Amen Loop, Comment this out if not wanted
live_loop :amen_loop do
  sample :loop_amen, beat_stretch: 2, amp: 0.5
  sleep 2
end

live_loop :cute_melody do
  use_synth :piano
  notes = (ring :C5, :E5, :G5, :B5)
  play notes.choose, release: [0.1, 0.2].choose, amp: rrand(0.3, 0.6)
  sleep [0.25, 0.5].choose
end

# Cute Bells
live_loop :cute_bells do
  use_synth :pretty_bell
  notes = (scale :C5, :major)
  play notes.choose, release: 0.3, amp: 0.3
  sleep 0.5
end



cute_sound_samples = [:ambi_piano, :ambi_giggle, :ambi_lunar_land]
more_cute_sound_samples = [:elec_bell, :elec_twip, :elec_pop]
even_more_cute_sound_samples = [ :ambi_piano]
cute_collection = cute_sound_samples + more_cute_sound_samples + even_more_cute_sound_samples


live_loop :random_cute_sounds, sync: :cute_melody do
  with_fx [:reverb, :echo, :flanger].choose, room: rrand(0.3, 0.7), phase: rrand(0.1, 0.7), decay: rrand(1, 3), mix: rrand(0.5, 0.8) do |fx|
    sample cute_collection.choose,
      rate: [0.8, 1, 1.2].choose,
      amp: rrand(0.1, 0.3),
      pitch: rrand(-12, 12),
      pan: rrand(-1, 1)
    sleep [2, 3].choose
  end
end

live_loop :cute_sounds do
  with_fx [:reverb, :echo, :flanger].choose, room: rrand(0.3, 0.7), phase: rrand(0.1, 0.7), decay: rrand(1, 3), mix: rrand(0.5, 0.8) do |fx|
    sample cute_sound_samples.choose,
      rate: [0.8, 1, 1.2].choose,
      amp: rrand(0.1, 0.3),
      pitch: rrand(-12, 12),
      pan: rrand(-1, 1)
    sleep [2, 3].choose
  end
end

live_loop :more_cute_sounds do
  with_fx [:echo, :flanger].choose, phase: rrand(0.2, 0.6), decay: rrand(1, 2), feedback: rrand(0.3, 0.7) do |fx|
    sample more_cute_sound_samples.choose,
      amp: rrand(0.2, 0.4),
      pitch: rrand(-7, 7),
      pan: rrand(-0.8, 0.8)
    sleep [1, 2].choose
  end
end

live_loop :even_more_cute_sounds do
  with_fx [:reverb, :echo, :flanger].choose, room: rrand(0.5, 0.9), phase: rrand(0.1, 0.5), decay: rrand(2, 4), mix: rrand(0.6, 0.9) do |fx|
    sample even_more_cute_sound_samples.choose,
      rate: [0.8, 1, 1.2].choose,
      amp: rrand(0.2, 0.4),
      pitch: rrand(-9, 9),
      pan: rrand(-1, 1)
    sleep [4, 5].choose
  end
end
