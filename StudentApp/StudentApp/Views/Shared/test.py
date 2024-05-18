# Importer le module RapidMiner
from rapidminer import Studio
# Initialiser RapidMiner Studio en spécifiant le chemin vers le répertoire de RapidMiner Studio
data = Studio(studio_home="C:/Program Files/RapidMiner/RapidMiner Studio")
# Lire les données d'entrée depuis une ressource locale
myinput = data.read_resource("C:/Users/MO KADI/Desktop/Ambari.csv")
def rm_main(myinput):
    

    # Exécuter un processus de prétraitement
    training_dataset_sample = data.run_process("C:/Users/MO KADI/Desktop/Ambari.csv", inputs=[myinput])
