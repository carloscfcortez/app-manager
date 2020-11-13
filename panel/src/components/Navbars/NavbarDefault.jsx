import React, { useState } from 'react'
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap'

const NavbarDefault = () => {
  const [isOpen, setIsOpen] = useState(false)

  const toggle = () => setIsOpen(!isOpen)

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Pomar Manager</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <NavItem>
              <NavLink href="/trees/">Árvores</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/groups/">Grupos</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/harvests/">Colheitas</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/species/">Espécies</NavLink>
            </NavItem>
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  )
}

export default NavbarDefault
