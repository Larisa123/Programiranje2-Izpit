import tkinter as tk

class Risanje:
    def __init__(self, master): #root je master
        self.platno = tk.Canvas(master, width=500, height=500)
        self.platno.pack()

        menu = tk.Menu(master)
        menu_edit = tk.Menu(menu)
        menu_window = tk.Menu(menu)
        menu_edit.add_command(label="Change color", command=self.change_color)

        master.config(menu=menu)
        menu.add_cascade(label="Edit", menu=menu_edit)
        menu.add_cascade(label="Window", menu=menu_window)

        okno = tk.Frame(master)
        okno.pack()

        # Napisi
        tk.Label(okno, text="Parametri").grid(row=1, column=1)
        tk.Label(okno, text="Velikost").grid(row=4, column=1)

        # Vnosna polja
        self.parametri = tk.Entry(okno)
        self.parametri.grid(row=1, column=2)
        self.polozaj_x = tk.Entry(okno)

        self.velikost = tk.Entry(okno)
        self.velikost.grid(row=4, column=2)


    def change_color(self):
        pass


# pobrisi vse: self.platno.delete(tk.ALL)

root = tk.Tk()
app = Risanje(root)

root.mainloop()