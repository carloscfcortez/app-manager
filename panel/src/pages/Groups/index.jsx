import { Container, Row, Col, Button, Table } from "reactstrap";
import NavbarDefault from "../../components/Navbars/NavbarDefault";
import styled from "styled-components";
import { useState, useEffect } from "react";
import Api from "./../../services";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

export default function Groups({ history }) {
  const [rows, setRows] = useState([]);

  useEffect(() => {
    async function loadData() {
      try {
        const response = await Api.get("/api/group");
        setRows(response);
      } catch (error) {}
    }
    loadData();
  }, []);
  return (
    <>
      <NavbarDefault />
      <ContainerBody fluid>
        <Row noGutters={true}>
          <Col>
            <Link to="/groups/edit">Teste Add</Link>
            <Button color="info" onClick={() => history.push("/groups/edit")}>
              <FontAwesomeIcon icon="plus-circle" /> Adicionar
            </Button>

            <Button outline color="dark">
              Atualizar
            </Button>
          </Col>
        </Row>
        <SpaceRow noGutters={true}>
          <Col md={12}>
            <Table striped>
              <thead>
                <tr>
                  <th>Código</th>
                  <th>Name</th>
                </tr>
              </thead>
              <tbody>
                {rows?.map((item, index) => {
                  return (
                    <tr key={index}>
                      <th scope="row">{item.Id}</th>
                      <td>{item.Name}</td>
                    </tr>
                  );
                })}
              </tbody>
            </Table>
          </Col>
        </SpaceRow>
      </ContainerBody>
    </>
  );
}

const ContainerBody = styled(Container)`
  padding-top: 10px;
`;

const SpaceRow = styled(Row)`
  padding-top: 5px;
`;
