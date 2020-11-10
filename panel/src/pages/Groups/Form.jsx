import React, { useState, useEffect } from "react";
import styled from "styled-components";
import {
  Container,
  Row,
  Col,
  Button,
  Card,
  CardHeader,
  CardFooter,
  CardBody,
  Input,
} from "reactstrap";
import NavbarDefault from "../../components/Navbars/NavbarDefault";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Api from "../../services/index";
import swal from "sweetalert";
export default function EditGroup(props) {
  const { match, history } = props;
  const [data, setData] = useState();

  const handleGoBack = () => {
    history.goBack("/groups");
  };

  useEffect(() => {
    async function load() {
      console.log("params", match?.params?.id);
      const { id } = match?.params;
      setData(await Api.get(`/group/${id}`));
    }
    load();
  }, [match?.params?.id]);

  const handleSave = async () => {
    try {
      if (data?.id) {
        await Api.put(`/group/${data?.Id}`, { ...data });
        swal("Sucesso!", "Registro atualizado com sucesso.", "success").then(
          (isConfirm) => {
            if (isConfirm) handleGoBack();
          }
        );
      } else {
        await Api.post(`/group`, { ...data });
        swal("Sucesso!", "Registro cadastrado com sucesso.", "success").then(
          (isConfirm) => {
            if (isConfirm) handleGoBack();
          }
        );
      }
    } catch (error) {}
  };

  const changeValue = (fieldName, value) => {
    var property = {};
    var descriptor = Object.create({
      enumerable: true,
      writable: true,
      configurable: true,
      value: null,
    });
    descriptor.value = value;
    Object.defineProperty(property, fieldName, descriptor);
    setData({ ...data, ...property });
  };
  return (
    <div>
      <NavbarDefault />
      <ContainerBody>
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <Row>
                  <Col>
                    <h3>Cadastro de Grupos</h3>
                  </Col>
                </Row>
              </CardHeader>
              <CardBody>
                <Row>
                  <Col md={3}>
                    <label>Nome</label>
                    <Input
                      onChange={(event) =>
                        changeValue("Name", event?.target?.value)
                      }
                      value={data?.Name}
                    />
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                {/* <Row>
                  <Col md={1}>
                    <Button
                      color="info"
                      onClick={() => history.goBack()}
                      outline
                    >
                      <FontAwesomeIcon icon="arrow-left" /> Voltar
                    </Button>
                  </Col>
                  <SpaceVertical />
                </Row> */}
                <Button
                  color="success"
                  onClick={handleSave}
                  className="float-md-left"
                >
                  <FontAwesomeIcon icon="check-circle" /> Salvar
                </Button>
                <Button
                  color="info"
                  onClick={handleGoBack}
                  outline
                  className="float-md-right"
                >
                  <FontAwesomeIcon icon="arrow-left" /> Voltar
                </Button>
              </CardFooter>
            </Card>
          </Col>
        </Row>
        <SpaceRow />
      </ContainerBody>
    </div>
  );
}

const ContainerBody = styled(Container)`
  padding-top: 10px;
`;

const SpaceRow = styled(Row)`
  padding-top: 5px;
`;

const SpaceVertical = styled("span")`
  padding-left: 5px;
`;
