import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  NavbarText,
} from "reactstrap";

const NavbarDefault = (props) => {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Pomar Manager</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <NavItem>
              <NavLink href="/components/">Árvores</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/groups/">Grupos</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/components/">Colheitas</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/components/">Espécies</NavLink>
            </NavItem>
            <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret>
                Relatórios
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem>Colheitas</DropdownItem>
                <DropdownItem>Árvores</DropdownItem>
                <DropdownItem divider />
                <DropdownItem>Grupos</DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </Nav>
          {/* <NavbarText>Simple Text</NavbarText> */}
        </Collapse>
      </Navbar>
    </div>
  );
};

export default NavbarDefault;
