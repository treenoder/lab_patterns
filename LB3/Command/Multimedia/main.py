from abc import ABC, abstractmethod


# Інтерфейс Команди
class Command(ABC):
    @abstractmethod
    def execute(self):
        pass

    @abstractmethod
    def undo(self):
        pass


# Приймачі
class VideoPlayer:
    def play_video(self, video_name):
        print(f"Playing video: {video_name}")

    def stop_video(self):
        print("Video stopped.")


class AudioSystem:
    def increase_volume(self):
        print("Volume increased.")

    def decrease_volume(self):
        print("Volume decreased.")


# Конкретні Команди
class PlayVideoCommand(Command):
    def __init__(self, video_player: VideoPlayer, video_name: str):
        self.video_player = video_player
        self.video_name = video_name

    def execute(self):
        self.video_player.play_video(self.video_name)

    def undo(self):
        self.video_player.stop_video()


class StopVideoCommand(Command):
    def __init__(self, video_player: VideoPlayer):
        self.video_player = video_player

    def execute(self):
        self.video_player.stop_video()

    def undo(self):
        print("Cannot undo stop video command.")


class IncreaseVolumeCommand(Command):
    def __init__(self, audio_system: AudioSystem):
        self.audio_system = audio_system

    def execute(self):
        self.audio_system.increase_volume()

    def undo(self):
        self.audio_system.decrease_volume()


class DecreaseVolumeCommand(Command):
    def __init__(self, audio_system: AudioSystem):
        self.audio_system = audio_system

    def execute(self):
        self.audio_system.decrease_volume()

    def undo(self):
        self.audio_system.increase_volume()


class RemoteControl:
    def __init__(self):
        self.commands = {}

    def set_command(self, button, command: Command):
        self.commands[button] = command

    def press_button(self, button):
        if button in self.commands:
            self.commands[button].execute()
        else:
            print(f"No command assigned to button '{button}'.")

    def press_undo(self, button):
        if button in self.commands:
            self.commands[button].undo()
        else:
            print(f"No command assigned to button '{button}'.")


if __name__ == "__main__":
    # Приймачі
    video_player = VideoPlayer()
    audio_system = AudioSystem()

    # Команди
    play_cmd = PlayVideoCommand(video_player, "Inception")
    stop_cmd = StopVideoCommand(video_player)
    inc_vol_cmd = IncreaseVolumeCommand(audio_system)
    dec_vol_cmd = DecreaseVolumeCommand(audio_system)

    # Інвокер
    remote = RemoteControl()
    remote.set_command("play", play_cmd)
    remote.set_command("stop", stop_cmd)
    remote.set_command("vol_up", inc_vol_cmd)
    remote.set_command("vol_down", dec_vol_cmd)

    # Використання
    remote.press_button("play")
    remote.press_button("vol_up")
    remote.press_button("vol_up")
    remote.press_button("stop")
    remote.press_undo("play")
    remote.press_button("vol_down")
    remote.press_undo("vol_down")

# Output:
# Playing video: Inception
# Volume increased.
# Volume increased.
# Video stopped.
# Video stopped.
# Volume decreased.
# Volume increased.
