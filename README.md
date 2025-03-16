# Simple RP Commands
Plugin adding some RolePlay Commands

# Commands:
.Me
.Do
.Pomoc
.Ooc
.Patrz
.Try
.Opis (Pokoju, Przedmiotu)
==============
# Config:
```yaml
# true = Plugin Właczony, false = Plugin Wyłączony
is_enabled: true
# Włącz tryb Debug - Nie działa
debug: false
# Ustawienia komend - Nie usuwać {0}, {1}, lub {2}
me:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Me」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</align></size>"'
do:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Do」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</color></align></size>'
patrz:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Patrz」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</color></align></size>'
ooc:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Ooc」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</color></align></size>'
try:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Try」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</color> <color=#003300>| {2}</color> </align></size>'
Opis:
  range: 15
  duration: 5
  format: '<size=25><align=left><color=#003300>🎭|「Opis」</color><color=#FFFF00>{0}</color> : <color=#727472>{1}</color></align></size>'
pomoc:
  range: 0
  duration: 0
  format: '<color=green>[ModMail]</color> <color=#ffcc00>{0}</color>: {1}'
# Maksymalna ilość znaków dla .opis
max_custom_info_length: 250
# Włącza lub wyłącza daną komende
enabled_commands:
  me: true
  do: true
  patrz: true
  ooc: true
  try: true
  Opis: true
  opis: true
  pomoc: true
```
==============
# Translations
```yaml
# Wiadomość się pokaże kiedy runda się jeszcze nie zaczeła
round_not_started: 'Nie możesz użyć jeszcze komendy bo runda się nie zaczeła!'
# Wiadomość o użyciu komendy.
usage: 'Wiadomość: .{0} <message>'
# Wiadomość się pokaże kiedy nie graćz chce użyć komendy.
only_players: 'Tylko gracze mogą użyć tej komendy.'
# Wiadomość się pokaże kiedy komenda zadziała poprawnie
message_sent: 'Twoja komenda zadziałała poprawnie.'
# Wiadomość się pokaże kiedy opis zostanie ustawiony.
custom_info_set: 'Twój opis został ustawiony!'
# Wiadomość się pokaże kiedy .opis jest zbyt długie
custom_info_too_long: 'Opis jest zbyt długi.'
# Wiadomość która się pokaże prz próbie użycia wyłączonej komendy
command_disabled: 'Ta komenda jest wyłączona.'
# Wiadomość zostanie pokazana kiedy ktoś użyje .pomoc
help_request_sent: 'Twoja Wiadomość została wysłana do staff''u.'
# Zbiór komend
command_names:
  me: me
  do: do
  patrz: look
  ooc: ooc
  try: try
  Opis: desc
  opis: opis
  pomoc: pomoc
# Zbiór tego co robią dane komendy
commands:
  me: Komenda Narracyjna 'Me'.
  do: Komenda Narracyjna 'Do'.
  patrz: Komenda Narracyjna 'patrz'.
  ooc: Komenda Narracyjna 'Ooc'.
  try: Komenda Narracyjna 'Try'.
  Opis: Komenda Narracyjna 'Opis'.
  opis: Ustawia opis.
  pomoc: Wysyła wiadomość do staffu serwera
# Zbiór tego co może się stać po użyciu .try
try_result:
  Udane: Udane
  NieUdane: NieUdane
```
==============
# That's all.
Have a nice day :3
