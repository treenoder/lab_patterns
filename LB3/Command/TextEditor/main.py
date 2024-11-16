from abc import ABC, abstractmethod


# Інтерфейс Команди
class Command(ABC):
    @abstractmethod
    def execute(self):
        pass

    @abstractmethod
    def undo(self):
        pass


# Приймач
class TextEditor:
    def __init__(self):
        self.text = ""

    def write(self, content):
        self.text += content
        print(f"Text after write: '{self.text}'")

    def delete(self, count):
        deleted = self.text[-count:]
        self.text = self.text[:-count]
        print(f"Text after delete: '{self.text}'")
        return deleted


# Конкретні Команди
class WriteCommand(Command):
    def __init__(self, editor: TextEditor, content: str):
        self.editor = editor
        self.content = content

    def execute(self):
        self.editor.write(self.content)

    def undo(self):
        self.editor.delete(len(self.content))


class DeleteCommand(Command):
    def __init__(self, editor: TextEditor, count: int):
        self.editor = editor
        self.count = count
        self.deleted_text = ""

    def execute(self):
        self.deleted_text = self.editor.delete(self.count)

    def undo(self):
        self.editor.write(self.deleted_text)


class EditorController:
    def __init__(self):
        self.undo_stack = []
        self.redo_stack = []

    def execute_command(self, command: Command):
        command.execute()
        self.undo_stack.append(command)
        self.redo_stack.clear()

    def undo(self):
        if self.undo_stack:
            command = self.undo_stack.pop()
            command.undo()
            self.redo_stack.append(command)
        else:
            print("Nothing to undo.")

    def redo(self):
        if self.redo_stack:
            command = self.redo_stack.pop()
            command.execute()
            self.undo_stack.append(command)
        else:
            print("Nothing to redo.")


if __name__ == "__main__":
    editor = TextEditor()
    controller = EditorController()

    # Запис тексту
    write_cmd1 = WriteCommand(editor, "Hello, ")
    controller.execute_command(write_cmd1)

    write_cmd2 = WriteCommand(editor, "World!")
    controller.execute_command(write_cmd2)

    # Видалення тексту
    delete_cmd = DeleteCommand(editor, 6)
    controller.execute_command(delete_cmd)

    # Відкат останньої команди (видалення)
    controller.undo()

    # Відкат попередньої команди (додавання "World!")
    controller.undo()

    # Повтор останньої скасованої команди (додавання "World!")
    controller.redo()

    # Повтор видалення
    controller.redo()

    # Спроба повтору при відсутності історії
    controller.redo()

# Output:
# Text after write: 'Hello, '
# Text after write: 'Hello, World!'
# Text after delete: 'Hello, '
# Text after write: 'Hello, World!'
# Text after delete: 'Hello, '
# Text after write: 'Hello, World!'
# Text after delete: 'Hello, '
# Nothing to redo.
