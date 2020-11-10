import { Container, Row, Col } from 'reactstrap';
import NavbarDefault from '../../components/Navbars/NavbarDefault';
import styled from 'styled-components';

export default function Dashboard() {
  return (
    <>
      <NavbarDefault />
      <ContainerBody fluid>
        <Row noGutters={true}>
          <Col>
            <h3>Seja Bem vindo!</h3>
          </Col>
        </Row>
      </ContainerBody>
    </>
  );
}

const ContainerBody = styled(Container)`
  padding-top: 10px;
`;
