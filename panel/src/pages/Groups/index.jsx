import {
  Container,
  Row,
  Col,
  Button,
  Table,
  Input,
  Card,
  CardHeader,
  CardBody,
} from "reactstrap";
import NavbarDefault from "../../components/Navbars/NavbarDefault";
import { useState, useEffect } from "react";
import Api from "./../../services";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import swal from "sweetalert";

export default function Groups({ history }) {
  const [rows, setRows] = useState(null);
  const [filter, setFilter] = useState();
  const [reload, setReload] = useState(false);

  useEffect(() => {
    async function reloadData() {
      try {
        const response = await Api.get("/group", { filter });
        setRows(response);
      } catch (error) {}
    }
    reloadData();
  }, [reload]);

  const handleFilter = ({ target }) => {
    setFilter(target?.value);
  };

  const handleDelete = async ({ Id }) => {
    const isConfirm = await swal({
      title: "Deseja Excluir o registro?",
      text: "As informações serão apagadas!",
      icon: "warning",
      buttons: true,
      dangerMode: true,
    });

    if (isConfirm) {
      await Api.delete(`/group/${Id}`);
      setReload(!reload);
    }
  };

  return (
    <>
      <NavbarDefault />
      <Container className="pt-3">
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <Row>
                  <Col>
                    <h3>Consulta de Grupos</h3>
                  </Col>

                  <Col>
                    <Button
                      color="info"
                      onClick={() => history.push("/groups/edit")}
                      className="float-md-right"
                    >
                      {" "}
                      <FontAwesomeIcon icon="plus-circle" /> Adicionar
                    </Button>
                  </Col>
                </Row>
              </CardHeader>
              <CardBody>
                {/* <SpaceRow /> */}
                <Row>
                  <Col md={5}>
                    <Input name="filter" onChange={handleFilter} />
                  </Col>
                  {/* <SpaceVertical /> */}
                  <Col>
                    <Button
                      outline
                      color="dark"
                      onClick={() => setReload(!reload)}
                    >
                      <FontAwesomeIcon icon="search" /> Consultar
                    </Button>
                  </Col>
                </Row>
                {/* <SpaceRow /> */}
                <Row className="pt-5">
                  <Col md={12}>
                    <Table striped>
                      <thead>
                        <tr>
                          <th width={100}></th>
                          <th>Código</th>
                          <th>Name</th>
                        </tr>
                      </thead>
                      <tbody>
                        {rows?.map((item, index) => {
                          return (
                            <tr key={index}>
                              <th>
                                <Button
                                  color="danger"
                                  size="sm"
                                  onClick={() => handleDelete(item)}
                                >
                                  <FontAwesomeIcon icon="trash" />
                                </Button>
                                <Button
                                  className="ml-2"
                                  color="info"
                                  size="sm"
                                  onClick={() =>
                                    history.push(`/groups/edit/${item.Id}`)
                                  }
                                >
                                  <FontAwesomeIcon icon="edit" />
                                </Button>
                              </th>
                              <th scope="row">{item.Id}</th>
                              <td>{item.Name}</td>
                            </tr>
                          );
                        })}
                      </tbody>
                    </Table>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
}
