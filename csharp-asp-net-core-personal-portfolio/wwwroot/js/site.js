// GitHub Projects Filtering and Expansion
let allProjects = [];
let currentFilter = 'all';
let isExpanded = false;

document.addEventListener('DOMContentLoaded', () => {
    // Store all projects initially
    const container = document.getElementById('github-projects-container');
    allProjects = Array.from(container.getElementsByClassName('github-project-card'));
    
    // Set up filter click handlers
    document.querySelectorAll('.filter-btn').forEach(btn => {
        btn.addEventListener('click', (e) => {
            e.preventDefault();
            const filter = e.target.dataset.filter;
            filterProjects(filter);
        });
    });

    // Setup smooth scrolling for navigation links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                const headerOffset = 80;
                const elementPosition = target.getBoundingClientRect().top;
                const offsetPosition = elementPosition + window.pageYOffset - headerOffset;

                window.scrollTo({
                    top: offsetPosition,
                    behavior: 'smooth'
                });
            }
        });
    });

    // Setup navbar highlighting
    setupNavHighlighting();

    // Close mobile menu on click
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
    const navbarCollapse = document.querySelector('.navbar-collapse');
    navLinks.forEach(link => {
        link.addEventListener('click', () => {
            if (navbarCollapse.classList.contains('show')) {
                document.querySelector('.navbar-toggler').click();
            }
        });
    });
});

function filterProjects(filter) {
    currentFilter = filter;
    const container = document.getElementById('github-projects-container');
    
    // Update active button state
    document.querySelectorAll('.filter-btn').forEach(btn => {
        btn.classList.toggle('btn-primary', btn.dataset.filter === filter);
        btn.classList.toggle('btn-outline-primary', btn.dataset.filter !== filter);
    });

    // Filter projects with animation
    const filteredProjects = allProjects.filter(project => {
        const name = project.querySelector('.card-title').textContent.toLowerCase();
        switch(filter) {
            case 'csharp':
                return name.startsWith('csharp');
            case 'react':
                return name.startsWith('react');
            case 'others':
                return !name.startsWith('csharp') && !name.startsWith('react');
            default:
                return true;
        }
    });

    // Add hiding class to trigger fade out
    Array.from(container.children).forEach(child => {
        child.classList.add('hiding');
    });

    // Wait for fade out animation
    setTimeout(() => {
        // Clear container
        container.innerHTML = '';

        // Add filtered projects (limited if not expanded)
        const displayCount = isExpanded ? filteredProjects.length : Math.min(3, filteredProjects.length);
        for (let i = 0; i < displayCount; i++) {
            const project = filteredProjects[i].cloneNode(true);
            project.classList.add('hiding');
            container.appendChild(project);
            
            // Trigger reflow
            project.offsetHeight;
            project.classList.remove('hiding');
        }

        // Update "See More" button visibility
        const seeMoreBtn = document.getElementById('see-more-btn');
        if (seeMoreBtn) {
            seeMoreBtn.style.display = filteredProjects.length > 3 ? 'block' : 'none';
        }
    }, 300);
}

function toggleProjects(button) {
    isExpanded = !isExpanded;
    button.innerHTML = isExpanded ? 
        'Show Less <i class="fas fa-chevron-up ms-1"></i>' : 
        'See More <i class="fas fa-chevron-down ms-1"></i>';
    filterProjects(currentFilter);
}

function setupNavHighlighting() {
    const sections = document.querySelectorAll('section[id]');
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
    
    window.addEventListener('scroll', () => {
        let current = '';
        sections.forEach(section => {
            const sectionTop = section.offsetTop - 100;
            if (window.pageYOffset >= sectionTop) {
                current = section.getAttribute('id');
            }
        });

        navLinks.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href').substring(1) === current) {
                link.classList.add('active');
            }
        });
    });
}
