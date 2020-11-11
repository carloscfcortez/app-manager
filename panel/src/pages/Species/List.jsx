import {
  Container,
  Row,
  Col,
  Button,
  Table,
  Input,
  Card,
  CardHeader,
  CardBody
} from 'reactstrap'
import NavbarDefault from './../../components/Navbars/NavbarDefault'
import { useState, useEffect } from 'react'
import Api from './../../services'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import swal from 'sweetalert'

export default function Species({ history }) {
  const [rows, setRows] = useState(null)
  const [filter, setFilter] = useState()
  const [reload, setReload] = useState(false)
  let title = 'Espécies'

  useEffect(() => {
    async function reloadData() {
      try {
        const response = await Api.get('/specie', { filter })
        if (response) setRows(response)
      } catch (error) {
        swal('Ops!', error?.message, 'error')
      }
    }
    reloadData()
  }, [reload])

  const handleFilter = ({ target }) => {
    setFilter(target?.value)
  }

  const handleDelete = async ({ Id }) => {
    const isConfirm = await swal({
      title: 'Deseja Excluir o registro?',
      text: 'As informações serão apagadas!',
      icon: 'warning',
      buttons: true,
      dangerMode: true
    })

    if (isConfirm) {
      await Api.delete(`/specie/${Id}`)
      setReload(!reload)
    }
  }

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
                    <h3>Consulta de {title}</h3>
                  </Col>

                  <Col>
                    <Button
                      color="info"
                      onClick={() => history.push('/species/create')}
                      className="float-md-right"
                    >
                      {' '}
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
                <Row className="pt-5">
                  <Col md={12}>
                    <Table striped>
                      <thead>
                        <tr>
                          <th width={100}></th>
                          <th>Código</th>
                          <th>Nome Popular</th>
                          <th>Nome Científico</th>
                        </tr>
                      </thead>
                      <tbody>
                        {rows?.length < 1 ? (
                          <tr>
                            <td className="alert alert-info" colSpan="4">
                              {' '}
                              Não possui Registros
                            </td>
                          </tr>
                        ) : (
                          rows?.map((item, index) => {
                            return (
                              <tr key={index}>
                                <th>
                                  <Button
                                    color="info"
                                    size="sm"
                                    onClick={() =>
                                      history.push(`/species/${item.Id}`)
                                    }
                                  >
                                    <FontAwesomeIcon icon="edit" />
                                  </Button>
                                  <Button
                                    className="ml-2"
                                    color="danger"
                                    size="sm"
                                    onClick={() => handleDelete(item)}
                                  >
                                    <FontAwesomeIcon icon="trash" />
                                  </Button>
                                </th>
                                <th scope="row">{item.Id}</th>
                                <td>{item.PopularName}</td>
                                <td>{item.ScientificName}</td>
                              </tr>
                            )
                          })
                        )}
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
  )
}
