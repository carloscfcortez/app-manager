import React, { useState, useEffect } from 'react'
import styled from 'styled-components'
import {
  Container,
  Row,
  Col,
  Button,
  Card,
  CardHeader,
  CardFooter,
  CardBody,
  Input
} from 'reactstrap'
import NavbarDefault from '../../components/Navbars/NavbarDefault'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Api from '../../services/index'
import swal from 'sweetalert'
import moment from 'moment'

export default function EditHarvest(props) {
  const { match, history } = props
  const [trees, setTrees] = useState([])
  const [data, setData] = useState({
    Information: '',
    TreeId: '',
    HarvestDate: new Date(),
    GrossWeight: ''
  })
  let title = 'Colheita'

  const handleGoBack = () => {
    history.goBack('/harvests')
  }

  useEffect(() => {
    ;(async function () {
      setTrees(await Api.get('/tree'))
    })()
  }, [])

  useEffect(() => {
    async function load() {
      const { id } = match?.params
      setData(await Api.get(`/harvest/${id}`))
    }
    if (match?.params?.id) load()
  }, [match?.params?.id])

  const handleSave = async () => {
    console.log(data)
    if (data?.Id) {
      await Api.put(`/harvest/${data?.Id}`, { ...data })
      swal('Sucesso!', 'Registro atualizado com sucesso.', 'success').then(
        (isConfirm) => {
          if (isConfirm) handleGoBack()
        }
      )
    } else {
      await Api.post(`/harvest`, { ...data })
      swal('Sucesso!', 'Registro cadastrado com sucesso.', 'success').then(
        (isConfirm) => {
          if (isConfirm) handleGoBack()
        }
      )
    }
  }

  const changeValue = (fieldName, value) => {
    console.log(value)
    var property = {}
    var descriptor = Object.create({
      enumerable: true,
      writable: true,
      configurable: true,
      value: null
    })
    descriptor.value = value
    Object.defineProperty(property, fieldName, descriptor)

    setData({ ...data, ...property })
  }
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
                    <h3>Cadastro de {title}</h3>
                  </Col>
                </Row>
              </CardHeader>
              <CardBody>
                <Row>
                  <Col md={6}>
                    <label>Informações</label>
                    <textarea
                      rows="4"
                      className="form-control"
                      type="text"
                      onChange={(event) =>
                        changeValue('Information', event?.target?.value)
                      }
                      required
                      defaultValue={data?.Information}
                    ></textarea>
                  </Col>
                  <Col md={3}>
                    <label>Data da Colheita</label>

                    <Input
                      type="date"
                      onChange={(event) =>
                        changeValue('HarvestDate', event?.target?.value)
                      }
                      required
                      // defaultValue={data?.HarvestDate}
                      defaultValue={moment(data?.HarvestDate)
                        .format('MM-DD-YYYY')
                        .toString()}
                    />
                  </Col>
                </Row>
                <Row>
                  <Col md={3}>
                    <label>Arvore</label>

                    <Input
                      type="select"
                      onChange={(event) =>
                        changeValue('TreeId', event?.target?.value)
                      }
                      value={data?.TreeId}
                    >
                      <option>Selecione a Árvore</option>
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
                    <label>Peso bruto</label>
                    <Input
                      type="number"
                      onChange={(event) =>
                        changeValue('GrossWeight', event?.target?.value)
                      }
                      value={data?.GrossWeight}
                    />
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
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
  )
}

const ContainerBody = styled(Container)`
  padding-top: 10px;
`

const SpaceRow = styled(Row)`
  padding-top: 5px;
`
