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
import moment from 'moment'

export default function Harvests({ history }) {
  const [trees, setTrees] = useState([])
  const [groups, setGroups] = useState([])
  const [species, setSpecies] = useState([])

  const [rows, setRows] = useState(null)
  const [filter, setFilter] = useState()
  const [reload, setReload] = useState(false)
  let title = 'Colheitas'

  useEffect(() => {
    ;(async function () {
      setTrees(await Api.get('/tree'))
      setGroups(await Api.get('/group'))
      setSpecies(await Api.get('/specie'))
    })()
  }, [])

  useEffect(() => {
    async function reloadData() {
      try {
        const response = await Api.get('/harvest', filter)
        if (response) setRows(response)
      } catch (error) {
        swal('Ops!', error?.message, 'error')
      }
    }
    reloadData()
  }, [reload])

  // const handleFilter = ({ target }) => {
  //   setFilter(target?.value)
  // }

  const handleDelete = async ({ Id }) => {
    const isConfirm = await swal({
      title: 'Deseja Excluir o registro?',
      text: 'As informações serão apagadas!',
      icon: 'warning',
      buttons: true,
      dangerMode: true
    })

    if (isConfirm) {
      await Api.delete(`/harvest/${Id}`)
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
                      onClick={() => history.push('/harvests/create')}
                      className="float-md-right"
                    >
                      {' '}
                      <FontAwesomeIcon icon="plus-circle" /> Adicionar
                    </Button>
                  </Col>
                </Row>
              </CardHeader>
              <CardBody>
                <Row>
                  <Col md={3}>
                    <label>Árvore</label>
                    <Input
                      type="select"
                      onChange={(event) =>
                        setFilter({
                          ...filter,
                          treeId: event?.target?.value
                        })
                      }
                    >
                      <option value="0">Selecione a Árvore</option>
                      {trees?.map((item) => (
                        <option key={item?.Id} value={item?.Id}>
                          {item?.Id +
                            ' - ' +
                            item?.Specie?.PopularName +
                            ' - ' +
                            item?.Specie?.ScientificName}
                        </option>
                      ))}
                    </Input>
                  </Col>
                  <Col md={3}>
                    <label>Grupos</label>
                    <Input
                      type="select"
                      onChange={(event) =>
                        setFilter({
                          ...filter,
                          groupId: event?.target?.value
                        })
                      }
                    >
                      <option value="0">Selecione o Grupo</option>
                      {groups?.map((item) => (
                        <option key={item?.Id} value={item?.Id}>
                          {item?.Id + ' - ' + item?.Name}
                        </option>
                      ))}
                    </Input>
                  </Col>
                  <Col md={3}>
                    <label>Espécies</label>
                    <Input
                      type="select"
                      onChange={(event) =>
                        setFilter({
                          ...filter,
                          specieId: event?.target?.value
                        })
                      }
                    >
                      <option value="0">Selecione a Espécie</option>
                      {species?.map((item) => (
                        <option key={item?.Id} value={item?.Id}>
                          {item?.Id +
                            ' - ' +
                            item?.PopularName +
                            ' - ' +
                            item?.ScientificName}
                        </option>
                      ))}
                    </Input>
                  </Col>
                </Row>
                <Row>
                  <Col md={3}>
                    <label>Periodo Inicio de Colheita</label>

                    <Input
                      type="date"
                      onChange={(event) =>
                        setFilter({
                          ...filter,
                          periodStart: event?.target?.value
                        })
                      }
                    />
                  </Col>
                  <Col md={3}>
                    <label>Periodo Fim de Colheita</label>
                    <Input
                      type="date"
                      onChange={(event) =>
                        setFilter({
                          ...filter,
                          periodEnd: event?.target?.value
                        })
                      }
                    />
                  </Col>
                </Row>
                <Row className="pt-3">
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
                          <th>Espécie</th>
                          <th>Grupo</th>
                          <th>Informações</th>
                          <th>Peso Bruto</th>
                          <th>Data da Colheita</th>
                        </tr>
                      </thead>
                      <tbody>
                        {rows?.length < 1 ? (
                          <tr>
                            <td className="alert alert-info" colSpan="7">
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
                                      history.push(`/harvests/${item.Id}`)
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
                                <td>{item?.Tree?.Specie?.PopularName}</td>
                                <td>{item?.Tree?.Group?.Name}</td>
                                <td>{item.Information}</td>
                                <td>{item.GrossWeight}</td>
                                <td>
                                  {moment(item?.HarvestDate).format(
                                    'DD/MM/YYYY'
                                  )}
                                </td>
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
