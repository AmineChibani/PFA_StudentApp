document.addEventListener('DOMContentLoaded', async function () {
    const searchInput = document.getElementById('searchBox');
    const villeInput = document.getElementById('searchBoxVille');
    const searchButton = document.getElementById('searchButton');
    let allUsers = [];
    let allCities = [];
    let allCategories = [];

    async function fetchData(url, setStateFunction) {
        try {
            const response = await fetch(url);
            const data = await response.json();
            setStateFunction(data);
        } catch (error) {
            console.error(`Failed to fetch data from ${url}:`, error);
        }
    }

    await fetchData('/BarreDeRecherche/GetAllUsers', data => allUsers = data);
    await fetchData('/BarreDeRecherche/GetAllCities', data => allCities = data);
    await fetchData('/BarreDeRecherche/GetAllCategories', data => allCategories = data);

    if (searchButton) {
        searchButton.addEventListener('click', function () {
            const userSearchTerm = searchInput ? searchInput.value.trim().toLowerCase() : '';
            const citySearchTerm = villeInput ? villeInput.value.trim().toLowerCase() : '';

            if (!userSearchTerm && !citySearchTerm) {
                window.location.href = `/Maroc`;
            } else if (userSearchTerm && !citySearchTerm) {
                window.location.href = `/GetAllCities/${encodeURIComponent(userSearchTerm)}`;
            } else if (!userSearchTerm && citySearchTerm) {
                window.location.href = `/GetAllCategories/${encodeURIComponent(citySearchTerm)}`;
            } else {
                window.location.href = `/Search/${encodeURIComponent(userSearchTerm)}/${encodeURIComponent(citySearchTerm)}`;
            }
        });
    }

    if (searchInput) {
        searchInput.addEventListener('input', function () {
            const filteredUsers = filterUsers();
            const filteredCategories = filterCategories();
            displayResults(filteredCategories, 'resultsCategories'); // Display categories first
            displayResults(filteredUsers, 'resultsUsers');
        });
    }

    if (villeInput) {
        villeInput.addEventListener('input', function () {
            const filteredCities = filterCities();
            displayResultsVille(filteredCities, 'resultsVille');
        });
    }

    function filterUsers() {
        const searchTerm = searchInput ? searchInput.value.toLowerCase() : '';
        return searchTerm ? allUsers.filter(user => {
            const fullName = user.nom.toLowerCase() + ' ' + user.prenom.toLowerCase();
            const reverseFullName = user.prenom.toLowerCase() + ' ' + user.nom.toLowerCase();
            return user.nom.toLowerCase().startsWith(searchTerm) ||
                user.prenom.toLowerCase().startsWith(searchTerm) ||
                fullName.startsWith(searchTerm) ||
                reverseFullName.startsWith(searchTerm);
        }) : [];
    }

    function filterCategories() {
        const searchTerm = searchInput ? searchInput.value.toLowerCase() : '';
        return searchTerm ? allCategories.filter(cat => cat.nomCategorie.toLowerCase().startsWith(searchTerm)) : [];
    }

    function filterCities() {
        const searchTerm = villeInput ? villeInput.value.toLowerCase() : '';
        return searchTerm ? allCities.filter(city => city.libelle.toLowerCase().startsWith(searchTerm)) : [];
    }

    function displayResults(items, resultDivId) {
        const resultsDiv = document.getElementById(resultDivId);
        resultsDiv.innerHTML = '';
        resultsDiv.style.display = items.length > 0 ? 'block' : 'none';

        items.forEach(item => {
            if ('nomCategorie' in item) {  // Catégorie
                const categoryDiv = document.createElement('div');
                categoryDiv.textContent = item.nomCategorie;
                categoryDiv.onclick = () => {
                    if (searchInput) {
                        searchInput.value = item.nomCategorie;
                        clearAllResults();
                    }
                };
                resultsDiv.appendChild(categoryDiv);
            } else {  // Utilisateur
                const itemLink = document.createElement('a');
                itemLink.href = `/UserProfile/${item.id}`;
                itemLink.textContent = `${item.nom} ${item.prenom} - ${item.email}`;
                itemLink.style.display = 'block';
                resultsDiv.appendChild(itemLink);
            }
        });
    }

    function displayResultsVille(cities, resultDivId) {
        const resultsDiv = document.getElementById(resultDivId);
        resultsDiv.innerHTML = '';
        cities.forEach(city => {
            const cityDiv = document.createElement('div');
            cityDiv.textContent = city.libelle;
            cityDiv.onclick = () => {
                if (villeInput) {
                    villeInput.value = city.libelle;
                    clearResults('resultsVille');
                }
            };
            resultsDiv.appendChild(cityDiv);
        });
        resultsDiv.style.display = cities.length > 0 ? 'block' : 'none';
    }

    function clearResults(resultDivId) {
        const resultsDiv = document.getElementById(resultDivId);
        resultsDiv.innerHTML = '';
        resultsDiv.style.display = 'none';
    }

    function clearAllResults() {
        clearResults('resultsCategories');
        clearResults('resultsUsers');
        clearResults('resultsVille');
    }
});
