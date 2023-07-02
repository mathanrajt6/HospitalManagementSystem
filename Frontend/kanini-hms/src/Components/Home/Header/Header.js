import './Header.css'

function Header()
{
    function toggleMenu() {
        var navLinks = document.getElementById("navLinks");
        if (navLinks.style.transform === "translateX(0%)") {
          navLinks.style.transform = "translateX(100%)";
        } else {
          navLinks.style.transform = "translateX(0%)";
        }
      }
      
          
    

    return(
        <div className="header">
            {/* <div className='header-title'>
                <h1 className='header-title-1'> 
                    KANINI H M S
                </h1>
            </div>
            <div className='header-content'> 
                <button className='header-item-5' >
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="black" class="bi bi-x-lg" viewBox="0 0 16 16">
                        <path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8 2.146 2.854Z"/>
                    </svg>
                </button>
                <span className='header-item-1'> 
                        Login
                </span>
                <span className='header-item-2'> 
                    Register
                </span>
                <span className='header-item-3'> 
                    About Us
                </span>
                <span className='header-item-4'> 
                    Contact Us
                </span>
                
            </div>

            <div className='header-content-ham'> 
                <button className='header-item-5' >
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="black" class="bi bi-x-lg" viewBox="0 0 16 16">
                        <path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8 2.146 2.854Z"/>
                    </svg>
                </button>
                <span className='header-item--ham-1'> 
                        Login
                </span>
                <span className='header-item--ham-2'> 
                    Register
                </span>
                <span className='header-item-ham-3'> 
                    About Us
                </span>
                <span className='header-item-ham-4'> 
                    Contact Us
                </span>
            </div>

            <div className='hamburger'>
                <button className='hamburger-item' > 
                    <svg  xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="black" class="bi bi-list" viewBox="0 0 16 16" >
                        <path fill-rule="evenodd" d="M2.5 12a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5z"/>
                    </svg>

                </button>
            </div>
                 */}



<header>
    <nav>
      <div class="navbar">
        <div class="logo">
          <a href="#">Logo</a>
        </div>
        <ul class="nav-links" id="navLinks">
          <li><a href="#">Home</a></li>
          <li><a href="#">About</a></li>
          <li><a href="#">Services</a></li>
          <li><a href="#">Contact</a></li>
        </ul>
        <div class="hamburger" onclick="toggleMenu()">
          <div class="line"></div>
          <div class="line"></div>
          <div class="line"></div>
        </div>
      </div>
    </nav>
  </header>
            
            
        </div>
    );
}

export default Header;